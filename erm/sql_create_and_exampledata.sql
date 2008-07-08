-- phpMyAdmin SQL Dump
-- version 2.11.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 08. Juli 2008 um 20:46
-- Server Version: 5.0.51
-- PHP-Version: 5.2.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Datenbank: `timetable`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `booking`
--

CREATE TABLE IF NOT EXISTS `booking` (
  `BOOK_ID` bigint(20) unsigned NOT NULL auto_increment,
  `CUR_ID` int(10) unsigned NOT NULL,
  `ROOM_ID` int(5) unsigned NOT NULL,
  `BOOK_BEGIN` datetime default NULL,
  `BOOK_END` datetime default NULL,
  `module_sub_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`BOOK_ID`),
  UNIQUE KEY `CUR_ID` (`CUR_ID`,`BOOK_BEGIN`,`module_sub_id`),
  KEY `BOOKING_FKIndex1` (`ROOM_ID`),
  KEY `BOOKING_FKIndex2` (`CUR_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=150 ;

--
-- Daten für Tabelle `booking`
--

INSERT INTO `booking` (`BOOK_ID`, `CUR_ID`, `ROOM_ID`, `BOOK_BEGIN`, `BOOK_END`, `module_sub_id`) VALUES
(27, 2, 1, '2008-06-09 17:30:00', '2008-06-09 19:00:00', 0),
(5, 1, 1, '2008-06-23 17:30:00', '2008-06-23 19:00:00', 0),
(3, 2, 1, '2008-06-30 15:45:00', '2008-06-30 17:15:00', 0),
(66, 3, 3, '2008-06-10 10:00:00', '2008-06-10 11:30:00', 0),
(102, 2, 2, '2008-06-24 10:00:00', '2008-06-24 11:30:00', 0),
(60, 1, 1, '2008-06-09 08:00:00', '2008-06-09 09:30:00', 0),
(40, 2, 1, '2008-06-12 17:30:00', '2008-06-12 19:00:00', 0),
(46, 2, 1, '2008-06-03 14:00:00', '2008-06-03 15:30:00', 0),
(12, 2, 2, '2008-06-23 12:00:00', '2008-06-23 13:30:00', 0),
(13, 2, 1, '2008-06-23 10:00:00', '2008-06-23 11:30:00', 0),
(65, 3, 1, '2008-06-24 08:00:00', '2008-06-24 09:30:00', 0),
(76, 1, 1, '2008-06-25 12:00:00', '2008-06-25 13:30:00', 0),
(54, 2, 1, '2008-07-02 10:00:00', '2008-07-02 11:30:00', 0),
(62, 1, 1, '2008-07-08 12:00:00', '2008-07-08 13:30:00', 0),
(19, 1, 1, '2008-06-30 10:00:00', '2008-06-30 11:30:00', 0),
(75, 2, 1, '2008-06-12 10:00:00', '2008-06-12 11:30:00', 0),
(61, 2, 1, '2008-06-10 14:00:00', '2008-06-10 15:30:00', 0),
(148, 4, 3, '2008-06-24 12:00:00', '2008-06-24 13:30:00', 3),
(36, 2, 1, '2008-06-09 14:00:00', '2008-06-09 15:30:00', 0),
(37, 2, 1, '2008-06-09 10:00:00', '2008-06-09 11:30:00', 0),
(57, 1, 1, '2008-07-15 08:00:00', '2008-07-15 09:30:00', 0),
(49, 1, 1, '2008-07-21 15:45:00', '2008-07-21 17:15:00', 0),
(51, 1, 1, '2008-08-04 17:30:00', '2008-08-04 19:00:00', 0),
(149, 4, 2, '2008-06-24 12:00:00', '2008-06-24 13:30:00', 4),
(147, 4, 2, '2008-06-23 17:30:00', '2008-06-23 19:00:00', 4),
(146, 4, 1, '2008-06-23 17:30:00', '2008-06-23 19:00:00', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `class`
--

CREATE TABLE IF NOT EXISTS `class` (
  `CLASS_ID` int(10) unsigned NOT NULL auto_increment,
  `FIELD_ID` int(5) unsigned NOT NULL,
  `CLASS_NAME` varchar(10) NOT NULL,
  `CLASS_COUNT` int(3) unsigned default NULL,
  `CLASS_TYP` int(1) unsigned NOT NULL,
  PRIMARY KEY  (`CLASS_ID`),
  KEY `CLASS_FKIndex1` (`FIELD_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `class`
--

INSERT INTO `class` (`CLASS_ID`, `FIELD_ID`, `CLASS_NAME`, `CLASS_COUNT`, `CLASS_TYP`) VALUES
(1, 1, 'IT 05', 25, 0),
(2, 2, 'SE 07', 19, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `class_period`
--

CREATE TABLE IF NOT EXISTS `class_period` (
  `CLASS_PERIOD_ID` int(10) unsigned NOT NULL auto_increment,
  `CLASS_ID` int(10) unsigned NOT NULL,
  `TERM_ID` int(5) unsigned default NULL,
  `CLASS_PERIOD_BEGIN` date default NULL,
  `CLASS_PERIOD_END` date default NULL,
  `CLASS_PERIOD_TYP` int(1) unsigned default NULL,
  PRIMARY KEY  (`CLASS_PERIOD_ID`),
  KEY `CLASS_PERIOD_FKIndex2` (`CLASS_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `class_period`
--

INSERT INTO `class_period` (`CLASS_PERIOD_ID`, `CLASS_ID`, `TERM_ID`, `CLASS_PERIOD_BEGIN`, `CLASS_PERIOD_END`, `CLASS_PERIOD_TYP`) VALUES
(1, 1, 6, '2008-06-04', '2008-08-08', 0),
(2, 2, 2, '2008-06-02', '2008-08-08', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `curriculum`
--

CREATE TABLE IF NOT EXISTS `curriculum` (
  `CUR_ID` int(10) unsigned NOT NULL auto_increment,
  `CLASS_PERIOD_ID` int(10) unsigned NOT NULL,
  `SUB_ID` int(5) unsigned NOT NULL,
  `CLASS_ID` int(10) unsigned NOT NULL,
  `CUR_CNT_SUB` int(3) unsigned default NULL,
  `MOD_GROUP_ID` int(10) unsigned default NULL,
  `lec_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`CUR_ID`),
  KEY `CURRICULUM_FKIndex1` (`SUB_ID`),
  KEY `CURRICULUM_FKIndex2` (`CLASS_ID`),
  KEY `CURRICULUM_FKIndex3` (`CLASS_PERIOD_ID`),
  KEY `lec_id` (`lec_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Daten für Tabelle `curriculum`
--

INSERT INTO `curriculum` (`CUR_ID`, `CLASS_PERIOD_ID`, `SUB_ID`, `CLASS_ID`, `CUR_CNT_SUB`, `MOD_GROUP_ID`, `lec_id`) VALUES
(1, 1, 1, 1, 12, NULL, 1),
(2, 1, 2, 1, 16, NULL, 2),
(3, 2, 2, 2, 36, NULL, 2),
(4, 1, 0, 1, 20, 1, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `defaultrooms`
--

CREATE TABLE IF NOT EXISTS `defaultrooms` (
  `ROOM_ID` int(5) unsigned NOT NULL,
  `CLASS_ID` int(10) unsigned NOT NULL,
  `priority` tinyint(3) unsigned default NULL,
  PRIMARY KEY  (`ROOM_ID`),
  KEY `defaultRooms_FKIndex1` (`CLASS_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `defaultrooms`
--

INSERT INTO `defaultrooms` (`ROOM_ID`, `CLASS_ID`, `priority`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `field`
--

CREATE TABLE IF NOT EXISTS `field` (
  `FIELD_ID` int(5) unsigned NOT NULL auto_increment,
  `FIELD_NAME` varchar(30) NOT NULL,
  PRIMARY KEY  (`FIELD_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `field`
--

INSERT INTO `field` (`FIELD_ID`, `FIELD_NAME`) VALUES
(1, 'Informatik'),
(2, 'Bankwirtschaft');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `language`
--

CREATE TABLE IF NOT EXISTS `language` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `LAN_ID` int(2) unsigned NOT NULL,
  `LAN_TXT` text NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Daten für Tabelle `language`
--


-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lecturer`
--

CREATE TABLE IF NOT EXISTS `lecturer` (
  `LEC_ID` int(5) unsigned NOT NULL auto_increment,
  `LEC_LNAME` varchar(30) NOT NULL,
  `LEC_GNAME` varchar(30) default NULL,
  `LEC_TEL` varchar(20) default NULL,
  PRIMARY KEY  (`LEC_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Daten für Tabelle `lecturer`
--

INSERT INTO `lecturer` (`LEC_ID`, `LEC_LNAME`, `LEC_GNAME`, `LEC_TEL`) VALUES
(1, 'Brunner', 'Ingolf', '12345678'),
(2, 'Scheiblich', 'Matthias', '98765432');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `room`
--

CREATE TABLE IF NOT EXISTS `room` (
  `ROOM_ID` int(5) unsigned NOT NULL auto_increment,
  `ROOM_NR` varchar(5) NOT NULL,
  `ROOM_NAME` varchar(30) default NULL,
  `ROOM_SEAT` int(3) unsigned default NULL,
  `room_type` tinyint(4) NOT NULL,
  PRIMARY KEY  (`ROOM_ID`),
  UNIQUE KEY `ROOM_NR` (`ROOM_NR`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Daten für Tabelle `room`
--

INSERT INTO `room` (`ROOM_ID`, `ROOM_NR`, `ROOM_NAME`, `ROOM_SEAT`, `room_type`) VALUES
(1, '103', 'Unterrichtsraum 103', 36, 0),
(2, '310', 'Raum 310', 40, 0),
(3, '104', 'Unterrichtsraum', 27, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `subject`
--

CREATE TABLE IF NOT EXISTS `subject` (
  `SUB_ID` int(5) unsigned NOT NULL auto_increment,
  `MOD_ID` int(5) unsigned default NULL,
  `SUB_NAME` varchar(30) NOT NULL,
  `SUB_TYP` int(1) unsigned NOT NULL,
  PRIMARY KEY  (`SUB_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Daten für Tabelle `subject`
--

INSERT INTO `subject` (`SUB_ID`, `MOD_ID`, `SUB_NAME`, `SUB_TYP`) VALUES
(1, NULL, 'Ökomanagement', 1),
(2, NULL, 'Qualitätsmanagent', 1),
(3, 1, 'Genetische Algorithmen', 2),
(4, 1, 'Löten', 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `timeunits`
--

CREATE TABLE IF NOT EXISTS `timeunits` (
  `TU_ID` int(5) unsigned NOT NULL auto_increment,
  `TU_START` int(5) unsigned NOT NULL,
  `TU_DURATION` int(3) unsigned NOT NULL,
  `TU_TYP` int(1) unsigned NOT NULL,
  PRIMARY KEY  (`TU_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Daten für Tabelle `timeunits`
--

INSERT INTO `timeunits` (`TU_ID`, `TU_START`, `TU_DURATION`, `TU_TYP`) VALUES
(1, 480, 90, 1),
(2, 570, 30, 0),
(3, 600, 90, 1),
(4, 690, 30, 0),
(5, 720, 90, 1),
(6, 810, 30, 0),
(7, 840, 90, 1),
(8, 930, 15, 0),
(9, 945, 90, 1),
(10, 1035, 15, 0),
(11, 1050, 90, 1);
