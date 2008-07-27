<?php

/**

  @defgroup mdl class mdl
  @brief library for data query and data manipulation
  @ingroup MODEL

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    library for data handle
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class mdl
{
  var $conn;    // database connection
  var $dbname;  // database name
  
  
  /**
      @brief    constructor (create database connection)
      @ingroup  mdl
  */
  function mdl()
  {
    // set dbname
    $this->dbname = "timetable";

    // create database connection
    $this->conn = @mysql_connect("localhost", "root", "Lilith");
  }









  /**
      @brief    execute query
      @ingroup  mdl
      @param    $sql  sql-query
      @return   two dimensional recordset <i>(ar[<line>][<rowname>] = < value >)</i>

  */
  function mdl_execute_query($sql)
  {
    // Daten abfragen
    $result = mysql_db_query ($this->dbname, $sql, $this->conn);
    if (mysql_errno() == 0) {
      $i = -1;
      if (mysql_num_rows($result) > 0) {
        while ($row = mysql_fetch_array($result)) {
          $i++;
          $ar[$i] = $row;
        }
      }
      mysql_free_result ($result);
      return $ar;
    } else {die('In den folgendem Sql-Statement ist ein Fehler aufgetreten: ' . $sql . '<br /><br />Fehler:' . mysql_error());}
  }
  








  /**
      @brief    update query
      @ingroup  mdl
      @param    $sql  sql-query
  */
  function mdl_update_query($sql)
  {
    $result = mysql_db_query ($this->dbname, $sql, $this->conn);
    if (mysql_errno() == 0) {
      $error = "";
      $lastId = mysql_insert_id($this->conn);
    } else {die('In den folgendem Sql-Statement ist ein Fehler aufgetreten: ' . $sql . '<BR><BR>Fehler:' . mysql_error());}
  }
  








  /**
      @brief    create and execute simple queries
      @ingroup  mdl
      @param    $table_name   table name
      @param    $pk_column    column name of primary key
      @param    $arPre        Array of preselected records
                              ($arPre[<index>] = < value >)
                              <i>if array is null, then all records in the table will be returned</i>
      @param    $order_column sort column
      @param    $extra_where  extra where-clause
      @return   two dimensional resultset <i>(ar[<line>][<rowname>] = < value >)</i>
  */
  function mdl_execute_simple_queries($table_name, $pk_column=null, $arPre=null, $order_column=null, $extra_where=null)
  {
    // sql query
    if (is_array($arPre))
    {
      $sWhere = join(", ", $arPre);
      $sWhere = " where ".$pk_column." in (".$sWhere.")";
    }
    
    if ($extra_where!="")
    {
      if ($sWhere != "") {$sWhere .= " and ".$extra_where;} else {$sWhere = " where ".$extra_where;}
    }
    
    $sql = "select * from ".$table_name.$sWhere.(($order_column != "") ? " order by ".$order_column : "");
    return $this->mdl_execute_query($sql);
  }
  
  







  /**
      @brief    check foreign key constraint
      @ingroup  mdl
      @param    $table_name   table which contains fk column
      @param    $arFk $arFk[0] = <column_name>; $arFk[1] = < value >;
      @return   number of fk records
  */
  function mdl_check_foreign_key($table_name, $arFk)
  {
    $sql = "select count(*) from ".$table_name." where ".$arFk[0]." = ".$arFk[1];

    $ar = $this->mdl_execute_query($sql);
    
    return $ar[0][0];
  }









  /**
      @brief    return the label of the requested language parameter
      @ingroup  mdl
      @param    $label_id     id of the requested label
      @param    $language_id  id of the requested language
      @return   label
  */
  function mdl_get_label($label_id, $language_id)
  {
    $sql = "select LAN_TXT from language where ID = ".$label_id." and LAN_ID = ".$language_id;
    $ar = $this->mdl_execute_query($sql);

    return $ar[0][0];
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    query the next free pk_id from a table
      @ingroup  mdl
      @param    $table_name table name
      @param    $pk_column  name of pk column
      @return   next free id
  */
  function mdl_get_next_id($tab_name, $pk_column)
  {
    $sql = "select max(".$pk_column.")+1 from ".$tab_name;
    $ar = $this->mdl_execute_query($sql);

    return ((intval($ar[0][0])!="") ? $ar[0][0] : 1) ;
  }
  
  
  
  
  
  



  /**
      @brief    generate and execute insert querys
      @ingroup  mdl
      @param    $arField $arField[<record_index>][<typ>][<field_name>] = < value > // typ = STRING|DATE|NUMBER|...
      @param    $arPk $arPk[0] = <column_name>; $arPk[1] = < value >;
      @param    $tab_name table name
      @param    $insert_typ insert|update
      @return   TRUE->error | FALSE->no error
  */
  function mdl_insert_data($arField, $arPk, $tab_name, $insert_typ)
  {
    $bErr = false;

    // run throug all saving records
    for ($i=0; $i<count($arField); $i++)
    {
      unset($arSql1);
      unset($arSql2);

      foreach ($arField[$i] as $data_typ => $arDATA)
      {
        foreach ($arDATA as $COL_NAME => $COL_VALUE)
        {
          switch ($data_typ)
          {
            case 'STRING':
              $COL_VALUE = "'".str_replace("'", "''", $COL_VALUE)."'";
            break;
            case 'NUMBER':
              $COL_VALUE = (($COL_VALUE=="") ? "null" : intval($COL_VALUE));
            break;
            case 'DATE':
              $COL_VALUE = "'".$COL_VALUE['JAHR']."-".$COL_VALUE['MONAT']."-".$COL_VALUE['TAG']."'";
            break;
            default: // error - unknown typ
              return true;
          }
          
          // prepare sql
          if ($insert_typ=="insert") {$arSql1[] = $COL_NAME; $arSql2[] = $COL_VALUE;} else {$arSql1[] = $COL_NAME." = ".$COL_VALUE;}
        }
      }
    }

    // record typ
    if ($insert_typ=="insert")
    {
      // get next free id
      $arPk[1] = $this->mdl_get_next_id($tab_name, $arPk[0]);

      // add to sql
      $arSql1[] = $arPk[0];
      $arSql2[] = $arPk[1];
    
      // generate insert sql
      $sql = "insert into ".$tab_name. " (".join(", ", $arSql1).") values (".join(", ", $arSql2).")";
    } else
    {
      // generate update sql
      $sql = "update ".$tab_name." set ".join(", ", $arSql1)." where ".$arPk[0]." =  ".intval($arPk[1]);
    }

    // exexute query
    $this->mdl_update_query($sql);

    return $bErr;
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate and execute delete query
      @ingroup  mdl
      @param    $arPk $arPk[0] = <column_name>; $arPk[1] = < value >;
      @param    $tab_name table name
  */
  function mdl_delete_data($arPk, $tab_name)
  {
    $sql = "delete from ".$tab_name." where ".$arPk[0]." = ".intval($arPk[1]);
    
    // exexute query
    $this->mdl_update_query($sql);
  }
  
  
  
  





  /* ------------------------------------------------------ */
  /* ------------------ special queries ------------------- */
  /* ------------------------------------------------------ */
  
  /**
      @brief    generate and execute insert querys for 'defaultrooms'
      @ingroup  mdl
      @param    $arSAVE array with all data
      @return   TRUE->error | FALSE->no error
  */
  function mdl_insert_defaultroom($arSAVE)
  {
    $bErr = FALSE;
print_r($arSAVE); die();
    for ($i++; $i<count($arSAVE); $i++)
    {


    }

    return $bErr;
  }







}











?>