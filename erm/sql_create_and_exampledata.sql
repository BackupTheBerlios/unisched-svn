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
  PRIMARY KEY  (`ROOM_ID`, `CLASS_ID`)
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

INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (1, 1, 'Studienrichtung');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (1, 2, 'field of study');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (2, 1, 'Möchten Sie diesen Datensatz wirklich löschen?');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (2, 2, 'Do you really want to delete this record?');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (3, 1, 'Neuer Datensatz');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (3, 2, 'New Record');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (4, 1, 'Speichern');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (4, 2, 'Save');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (5, 1, 'Bezeichnung');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (5, 2, 'description');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (6, 1, '<#L1#> bis <#L2#> Zeichen');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (6, 2, '<#L1#> to <#L2#> characters');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (7, 1, 'Angaben sind nicht korrekt (betroffene Felder sind rot markiert).');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (7, 2, 'incorrect data (fields are red marked)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (8, 1, 'Fehler beim Speichern der Daten aufgetreten (Bitte wenden Sie sich an Ihren Anwendungsbetreuer).');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (8, 2, 'a saving error has occurred (please contact the administrator)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (9, 1, 'Datensatz ''<#NAME#>'' kann nicht entfernt werden, da  <#ANZAHL#> Datensätze in ''<#FK_NAME#>'' existieren.');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (9, 2, 'record ''<#NAME#>'' can not be deleted, there are <#ANZAHL#> records in ''<#FK_NAME#>''.');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (10, 1, 'Daten erfolgreich gespeichert.');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (10, 2, 'Data succesfully saved.');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (11, 1, 'Bezeichnung existiert bereits');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (11, 2, 'description still exist');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (12, 1, 'Seminargruppe');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (12, 2, 'class');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (13, 1, 'Vorname');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (13, 2, 'first name');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (14, 1, 'Nachname');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (14, 2, 'last name');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (15, 1, 'Telefonnr.');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (15, 2, 'telephone nr');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (16, 1, 'Name existiert bereits');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (16, 2, 'name still exist');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (17, 1, 'Vorlesung');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (17, 2, 'lecture');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (18, 1, 'Prüfung');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (18, 2, 'examination');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (19, 1, 'Kürzel');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (19, 2, 'token');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (20, 1, 'Typ');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (20, 2, 'type');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (21, 1, 'Dozent');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (21, 2, 'lecturer');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (22, 1, 'Curriculum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (22, 2, 'curriculum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (23, 1, 'ungültiger Wert');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (23, 2, 'false value');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (24, 1, 'Kürzel existiert bereits');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (24, 2, 'token still exist');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (25, 1, 'Vorlesung');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (25, 2, 'lecture');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (26, 1, 'Modul');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (26, 2, 'module');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (27, 1, 'Werte zwischen <#N1#> and <#N2#>');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (27, 2, 'values between <#N1#> and <#N2#>');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (28, 1, 'Nummer existiert bereits');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (28, 2, 'number still exist');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (29, 1, 'Buchung (Stundenplan)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (29, 2, 'booking');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (30, 1, 'Standardraum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (30, 2, 'default room');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (31, 1, 'Nr');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (31, 2, 'nr');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (32, 1, 'Sitze');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (32, 2, 'seats');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (33, 1, 'Räume');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (33, 2, 'rooms');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (34, 1, 'Studienzeitraum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (34, 2, 'class period');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (35, 1, 'Studenten');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (35, 2, 'students');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (36, 1, 'Diplom');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (36, 2, 'diplom');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (37, 1, 'Bachelor');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (37, 2, 'bachelor');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (38, 1, 'ungültiges Datum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (38, 2, 'false date');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (39, 1, 'Semester');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (39, 2, 'term');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (40, 1, 'Theorie');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (40, 2, 'theory');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (41, 1, 'Praxis');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (41, 2, 'practice');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (42, 1, 'Beginn (tt.mm.jjjj)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (42, 2, 'begin (dd.mm.yyyy)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (43, 1, 'Ende (tt.mm.jjjj)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (43, 2, 'end (dd.mm.yyyy)');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (44, 1, 'Aktion');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (44, 2, 'action');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (45, 1, 'Ende vor Beginn');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (45, 2, 'end vor begin');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (46, 1, 'Stammdaten');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (46, 2, 'master data');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (47, 1, 'Titel');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (47, 2, 'title');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (48, 1, 'sehr hoch');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (48, 2, 'very high');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (49, 1, 'hoch');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (49, 2, 'high');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (50, 1, 'normal');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (50, 2, 'normal');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (51, 1, 'niedrig');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (51, 2, 'low');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (52, 1, 'sehr niedrig');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (52, 2, 'very low');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (53, 1, 'Raum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (53, 2, 'room');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (54, 1, 'Priorität');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (54, 2, 'priority');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (55, 1, 'Hinweis: Bitte zuerst Seminargruppen einpflegen');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (55, 2, 'information: please enter classes first');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (56, 1, 'Fach');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (56, 2, 'subject');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (57, 1, 'Stunden');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (57, 2, 'lessons');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (58, 1, 'Hinweis: Bitte zuerst Studienzeiträume einpflegen');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (58, 2, 'information: please enter class periods first');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (58, 1, 'Hinweis: Bitte zuerst Studienzeiträume einpflegen');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (58, 2, 'information: please enter class periods first');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (59, 1, 'Vorlesungsraum');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (59, 2, 'lecture room');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (60, 1, 'Labor');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (60, 2, 'labor');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (61, 1, 'Hinweis');
INSERT INTO `language` (`ID`, `LAN_ID`, `LAN_TXT`) VALUES (61, 2, 'information');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lecturer`
--

DROP TABLE IF EXISTS `lecturer`;
CREATE TABLE `lecturer` (
  `LEC_ID` int(5) unsigned NOT NULL auto_increment,
  `LEC_LNAME` varchar(30) NOT NULL,
  `LEC_GNAME` varchar(30) NOT NULL,
  `LEC_TIT` varchar(10) default NULL,
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
  `SUB_NAME` varchar(12) NOT NULL,
  `SUB_TYP` int(1) unsigned NOT NULL,
  `SUB_LONG_NAME` varchar(50) NOT NULL,
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
