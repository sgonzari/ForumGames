-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 07, 2021 at 07:30 PM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_games`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id_category` int(4) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id_category`, `name`) VALUES
(1, 'RPG'),
(2, 'MMO'),
(3, 'FPS'),
(4, 'Acción'),
(5, 'Arcade'),
(6, 'Deportivo'),
(7, 'Simulación'),
(8, 'Hack and Slash'),
(9, 'Carreras'),
(10, 'Aventura'),
(11, 'Indie'),
(12, 'Supervivencia');

-- --------------------------------------------------------

--
-- Table structure for table `comments`
--

CREATE TABLE `comments` (
  `id_comment` int(4) NOT NULL,
  `fk_id_game` int(4) NOT NULL,
  `fk_username` varchar(25) NOT NULL,
  `comment` varchar(255) NOT NULL,
  `date` date DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE `games` (
  `id_game` int(4) NOT NULL,
  `fk_username` varchar(25) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `launch_date` date DEFAULT NULL,
  `height` float NOT NULL,
  `multiplayer` tinyint(1) NOT NULL,
  `newComment` tinyint(1) NOT NULL DEFAULT 0,
  `url` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`id_game`, `fk_username`, `title`, `description`, `launch_date`, `height`, `multiplayer`, `newComment`, `url`) VALUES
(79, 'PacoFlipendo', 'Final Fantasy XIV', 'Un MMO más', '2020-11-11', 125, 1, 0, 'https://a');

-- --------------------------------------------------------

--
-- Table structure for table `games_category`
--

CREATE TABLE `games_category` (
  `fk_id_game` int(4) NOT NULL,
  `fk_id_category` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `games_category`
--

INSERT INTO `games_category` (`fk_id_game`, `fk_id_category`) VALUES
(79, 2);

-- --------------------------------------------------------

--
-- Table structure for table `games_platforms`
--

CREATE TABLE `games_platforms` (
  `fk_id_game` int(4) NOT NULL,
  `fk_id_platform` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `games_platforms`
--

INSERT INTO `games_platforms` (`fk_id_game`, `fk_id_platform`) VALUES
(79, 1),
(79, 2),
(79, 4);

-- --------------------------------------------------------

--
-- Table structure for table `platforms`
--

CREATE TABLE `platforms` (
  `id_platform` int(11) NOT NULL,
  `platform` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `platforms`
--

INSERT INTO `platforms` (`id_platform`, `platform`) VALUES
(1, 'PC'),
(2, 'PlayStation 4'),
(3, 'Xbox One'),
(4, 'PlayStation 3'),
(5, 'Xbox 360'),
(6, 'Nintendo Switch');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `username` varchar(25) NOT NULL,
  `group` varchar(25) NOT NULL DEFAULT 'user',
  `first_name` varchar(25) NOT NULL,
  `surname` varchar(25) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `phone` int(10) DEFAULT NULL,
  `RegisterDate` datetime NOT NULL DEFAULT current_timestamp(),
  `passwd` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`username`, `group`, `first_name`, `surname`, `email`, `phone`, `RegisterDate`, `passwd`) VALUES
('admin', 'admin', 'ForumGames', 'Administrador', '', NULL, '2021-06-04 00:00:00', 'd0ab4b41c059c4308f57ebd57b13f90d'),
('Orion', 'user', 'J', 'OC', 'jotasevenstar@gmail.com', 687006713, '2021-06-06 00:00:00', '509e9ee04fb4c83029334af5f1c61fd0'),
('PacoFlipendo', 'user', 'Paco', 'Flipendo', '', NULL, '2021-06-06 00:00:00', 'c901a7c784b6b807e6dc46d115833307'),
('prueba', 'user', 'Prueba', 'Pruebaza', 'prueba@gmail.es', NULL, '2021-06-04 00:00:00', 'f8032d5cae3de20fcec887f395ec9a6a'),
('sebas', 'admin', 'Sebastián', 'González Ríos', 'sebastiangr456@gmail.com', 635310288, '2021-06-04 00:00:00', 'f8032d5cae3de20fcec887f395ec9a6a'),
('  a   ', 'user', '  a   ', '  a   ', 'qcd80403@eoopy.com', 632542142, '2021-06-05 00:00:00', '81dc9bdb52d04dc20036dbd8313ed055'),
('    ', 'user', '    ', '    ', 'fev11781@zwoho.com', 632545214, '2021-06-05 00:00:00', '81dc9bdb52d04dc20036dbd8313ed055'),
('     ', 'user', '    ', '    ', 'ymw33176@eoopy.com', NULL, '2021-06-05 00:00:00', '81dc9bdb52d04dc20036dbd8313ed055'),
('         ', 'user', '         ', '         ', 'pwe18025@cuoly.com', 632541241, '2021-06-05 00:00:00', '81dc9bdb52d04dc20036dbd8313ed055'),
('             ', 'user', '             ', '             ', 'hpw60898@zwoho.com', 63245124, '2021-06-05 00:00:00', '81dc9bdb52d04dc20036dbd8313ed055');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id_category`);

--
-- Indexes for table `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`id_comment`),
  ADD KEY `FK_Game` (`fk_id_game`),
  ADD KEY `FK_User` (`fk_username`);

--
-- Indexes for table `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id_game`),
  ADD KEY `Users_FK` (`fk_username`);

--
-- Indexes for table `games_category`
--
ALTER TABLE `games_category`
  ADD PRIMARY KEY (`fk_id_game`,`fk_id_category`),
  ADD KEY `Category_Game_FK` (`fk_id_category`);

--
-- Indexes for table `games_platforms`
--
ALTER TABLE `games_platforms`
  ADD PRIMARY KEY (`fk_id_game`,`fk_id_platform`),
  ADD KEY `Platform_Game_FK` (`fk_id_platform`);

--
-- Indexes for table `platforms`
--
ALTER TABLE `platforms`
  ADD PRIMARY KEY (`id_platform`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id_category` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `comments`
--
ALTER TABLE `comments`
  MODIFY `id_comment` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `id_game` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;

--
-- AUTO_INCREMENT for table `platforms`
--
ALTER TABLE `platforms`
  MODIFY `id_platform` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `comments`
--
ALTER TABLE `comments`
  ADD CONSTRAINT `FK_Game` FOREIGN KEY (`fk_id_game`) REFERENCES `games` (`id_game`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_User` FOREIGN KEY (`fk_username`) REFERENCES `users` (`username`) ON DELETE CASCADE;

--
-- Constraints for table `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `Users_FK` FOREIGN KEY (`fk_username`) REFERENCES `users` (`username`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `games_category`
--
ALTER TABLE `games_category`
  ADD CONSTRAINT `Category_Game_FK` FOREIGN KEY (`fk_id_category`) REFERENCES `category` (`id_category`),
  ADD CONSTRAINT `Game_Category_FK` FOREIGN KEY (`fk_id_game`) REFERENCES `games` (`id_game`) ON DELETE CASCADE;

--
-- Constraints for table `games_platforms`
--
ALTER TABLE `games_platforms`
  ADD CONSTRAINT `Game_Platform_FK` FOREIGN KEY (`fk_id_game`) REFERENCES `games` (`id_game`) ON DELETE CASCADE,
  ADD CONSTRAINT `Platform_Game_FK` FOREIGN KEY (`fk_id_platform`) REFERENCES `platforms` (`id_platform`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
