-- phpMyAdmin SQL Dump
-- version 2.11.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 26. Juli 2008 um 12:57
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

DROP TABLE IF EXISTS `booking`;
CREATE TABLE `booking` (
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=168 ;

--
-- Daten für Tabelle `booking`
--

INSERT INTO `booking` (`BOOK_ID`, `CUR_ID`, `ROOM_ID`, `BOOK_BEGIN`, `BOOK_END`, `module_sub_id`) VALUES
(3, 2, 1, '2008-06-30 15:45:00', '2008-06-30 17:15:00', 0),
(66, 3, 3, '2008-06-10 10:00:00', '2008-06-10 11:30:00', 0),
(102, 2, 3, '2008-06-24 12:00:00', '2008-06-24 13:30:00', 0),
(40, 2, 1, '2008-06-12 17:30:00', '2008-06-12 19:00:00', 0),
(46, 2, 1, '2008-06-03 14:00:00', '2008-06-03 15:30:00', 0),
(65, 3, 1, '2008-06-24 08:00:00', '2008-06-24 09:30:00', 0),
(76, 1, 1, '2008-06-25 12:00:00', '2008-06-25 13:30:00', 0),
(54, 2, 1, '2008-07-02 10:00:00', '2008-07-02 11:30:00', 0),
(62, 1, 1, '2008-07-08 12:00:00', '2008-07-08 13:30:00', 0),
(19, 1, 1, '2008-06-30 10:00:00', '2008-06-30 11:30:00', 0),
(75, 2, 1, '2008-06-12 10:00:00', '2008-06-12 11:30:00', 0),
(61, 2, 1, '2008-06-10 14:00:00', '2008-06-10 15:30:00', 0),
(154, 4, 2, '2008-06-26 10:00:00', '2008-06-26 11:30:00', 4),
(37, 2, 3, '2008-06-09 10:00:00', '2008-06-09 11:30:00', 0),
(57, 1, 1, '2008-07-15 08:00:00', '2008-07-15 09:30:00', 0),
(49, 1, 1, '2008-07-21 15:45:00', '2008-07-21 17:15:00', 0),
(51, 1, 1, '2008-08-04 17:30:00', '2008-08-04 19:00:00', 0),
(155, 5, 1, '2008-06-26 10:00:00', '2008-06-26 11:30:00', 4),
(153, 5, 1, '2008-06-26 10:00:00', '2008-06-26 11:30:00', 3),
(152, 4, 1, '2008-06-26 10:00:00', '2008-06-26 11:30:00', 3),
(157, 5, 1, '2008-06-24 14:00:00', '2008-06-24 15:30:00', 3),
(159, 5, 1, '2008-06-24 14:00:00', '2008-06-24 15:30:00', 4),
(161, 5, 1, '2008-06-25 10:00:00', '2008-06-25 11:30:00', 3),
(163, 5, 1, '2008-06-25 10:00:00', '2008-06-25 11:30:00', 4),
(164, 4, 1, '2008-06-25 15:45:00', '2008-06-25 17:15:00', 3),
(165, 5, 1, '2008-06-25 15:45:00', '2008-06-25 17:15:00', 3),
(166, 4, 1, '2008-06-25 15:45:00', '2008-06-25 17:15:00', 4),
(167, 5, 1, '2008-06-25 15:45:00', '2008-06-25 17:15:00', 4);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `class`
--

DROP TABLE IF EXISTS `class`;
CREATE TABLE `class` (
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

DROP TABLE IF EXISTS `class_period`;
CREATE TABLE `class_period` (
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

DROP TABLE IF EXISTS `curriculum`;
CREATE TABLE `curriculum` (
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Daten für Tabelle `curriculum`
--

INSERT INTO `curriculum` (`CUR_ID`, `CLASS_PERIOD_ID`, `SUB_ID`, `CLASS_ID`, `CUR_CNT_SUB`, `MOD_GROUP_ID`, `lec_id`) VALUES
(1, 1, 1, 1, 12, NULL, 1),
(2, 1, 2, 1, 16, NULL, 2),
(3, 2, 2, 2, 36, NULL, 2),
(4, 1, 0, 1, 20, 1, 0),
(5, 2, 0, 2, 20, 1, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `defaultrooms`
--

DROP TABLE IF EXISTS `defaultrooms`;
CREATE TABLE `defaultrooms` (
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

DROP TABLE IF EXISTS `field`;
CREATE TABLE `field` (
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

DROP TABLE IF EXISTS `language`;
CREATE TABLE `language` (
  `ID` int(10) unsigned NOT NULL,
  `LAN_ID` int(2) unsigned NOT NULL,
  `LAN_TXT` text NOT NULL,
  PRIMARY KEY  (`ID`,`LAN_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `language`
--

INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES
(500, 1, 'Laden'),
(500, 2, 'Load'),
(501, 1, 'Aktualisieren'),
(501, 2, 'Refresh'),
(502, 1, 'Fächer'),
(502, 2, 'Subjects'),
(503, 1, 'Woche'),
(503, 2, 'Week'),
(504, 1, 'Monat'),
(504, 2, 'Month'),
(505, 1, 'Gesamtzeitraum'),
(505, 2, 'Period'),
(506, 1, 'Montag'),
(506, 2, 'Monday'),
(507, 1, 'Dienstag'),
(507, 2, 'Tuesday'),
(508, 1, 'Mittwoch'),
(508, 2, 'Wednesday'),
(509, 1, 'Donnerstag'),
(509, 2, 'Thursday'),
(510, 1, 'Freitag'),
(510, 2, 'Friday'),
(511, 1, 'Samstag'),
(511, 2, 'Saturday'),
(512, 1, 'Semester'),
(512, 2, 'Term'),
(513, 1, 'Von'),
(513, 2, 'From'),
(514, 1, 'Bis'),
(514, 2, 'To'),
(515, 1, 'Standard-Räume'),
(515, 2, 'Standard rooms'),
(516, 1, 'Labore'),
(516, 2, 'Laboratories'),
(517, 1, 'Sonstige'),
(517, 2, 'Miscellaneous'),
(518, 1, 'Zeitplanung'),
(518, 2, 'Time scheduling'),
(519, 1, 'Raumplanung'),
(519, 2, 'Room scheduling'),
(520, 1, 'Matrikel'),
(520, 2, 'Register'),
(521, 1, 'Zur Startseite'),
(522, 1, 'Zeitraum'),
(523, 1, 'Zum Bearbeiten der Räume zu diesem Zeitpunkt klicken Sie bitte doppelt auf die gewünschte Zeit.'),
(524, 1, 'Vorlesung bearbeiten'),
(525, 1, 'Modul bearbeiten'),
(526, 1, 'Standardräume dieser Seminargruppe anzeigen'),
(527, 1, 'Labore anzeigen'),
(528, 1, 'Sonstige Räume anzeigen'),
(529, 1, 'Zurück'),
(530, 1, 'Weiter'),
(531, 1, 'Dieses Modul benötigt mehrere Räume. Bitte legen Sie diese in der Raumplanung fest.'),
(532, 1, 'Der Standardraum für dieses Modul ist zu diesem Termin leider bereits von einer anderen Seminargruppe belegt.'),
(533, 1, 'Der Standardraum für diese Vorlesung ist zu diesem Termin leider bereits von einer anderen Seminargruppe belegt.'),
(534, 1, 'Zu diesem Zeitpunkt ist bereits eine andere Vorlesung geplant.'),
(535, 1, 'Sämtliche Vorlesungen dieses Faches, die laut Curriculum vorgeschrieben sind, sind bereits verplant.'),
(536, 1, 'Zu diesem Zeitpunkt ist bereits eine andere Vorlesung geplant.'),
(521, 2, 'Homepage'),
(522, 2, 'Timeframe'),
(523, 2, 'For arranging the rooms for this point in time, please double click the requested time.'),
(524, 2, 'Edit lecture'),
(525, 2, 'Edit module'),
(526, 2, 'Show standard room of this class'),
(527, 2, 'Show laboratories'),
(528, 2, 'Show miscellaneous rooms'),
(529, 2, 'Backward'),
(530, 2, 'Forward'),
(531, 2, 'This module needs more than one room. Please use the room scheduling.'),
(532, 2, 'The standard room is not available for this time. Please use the room scheduling.'),
(533, 2, 'The standard room is not available for this time. Please use the room scheduling.'),
(534, 2, 'For this point of time a lecture is already planned.'),
(535, 2, 'All needed lectures have already been planned.');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lecturer`
--

DROP TABLE IF EXISTS `lecturer`;
CREATE TABLE `lecturer` (
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

DROP TABLE IF EXISTS `room`;
CREATE TABLE `room` (
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

DROP TABLE IF EXISTS `subject`;
CREATE TABLE `subject` (
  `SUB_ID` int(5) unsigned NOT NULL auto_increment,
  `MOD_ID` int(5) unsigned default NULL,
  `SUB_NAME` varchar(8) NOT NULL,
  `SUB_TYP` int(1) unsigned NOT NULL,
  `SUB_LONG_NAME` varchar(30) NOT NULL,
  PRIMARY KEY  (`SUB_ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Daten für Tabelle `subject`
--

INSERT INTO `subject` (`SUB_ID`, `MOD_ID`, `SUB_NAME`, `SUB_TYP`, `SUB_LONG_NAME`) VALUES
(1, NULL, 'ÖkoM', 1, 'Ökomanagement'),
(2, NULL, 'QM', 1, 'Qualitätsmanagement'),
(3, 1, 'Gen Alg', 2, 'Genetische Algorithmen'),
(4, 1, 'Löten', 2, 'Löten');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `timeunits`
--

DROP TABLE IF EXISTS `timeunits`;
CREATE TABLE `timeunits` (
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
