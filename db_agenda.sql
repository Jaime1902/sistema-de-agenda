-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-06-2023 a las 17:14:44
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_agenda`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contactos`
--

CREATE TABLE `contactos` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `nombres` varchar(50) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `numero` varchar(20) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `fecha_registro` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `contactos`
--

INSERT INTO `contactos` (`id`, `usuario_id`, `nombres`, `apellidos`, `numero`, `correo`, `fecha_registro`) VALUES
(1, 1, 'Jose', 'perez', '+505 89406759', 'Jose@gmail.com', '2023-05-29'),
(4, 3, 'Jose Alex', 'perez', '+505 89406758', 'alex@gmail.com', '2023-05-29'),
(6, 1, 'Chariot', 'Tennewell', '264-937-9557', 'ctennewell5@latimes.com', '2023-05-25'),
(7, 1, 'Genevra', 'Kettlesing', '441-673-9619', 'gkettlesing6@ocn.ne.jp', '2023-05-25'),
(8, 1, 'Lazaro', 'Odger', '868-610-4031', 'lodger7@bravesites.com', '2023-05-25'),
(9, 1, 'Avril', 'Mathiot', '607-935-3921', 'amathiot8@hud.gov', '2023-05-25'),
(10, 1, 'Clemmy', 'MacCook', '813-209-2142', 'cmaccook9@slashdot.org', '2023-05-25'),
(11, 1, 'Bordie', 'Buckam', '916-436-7655', 'bbuckama@tripod.com', '2023-05-25'),
(12, 1, 'Carmelia', 'Veale', '774-447-2551', 'cvealeb@lulu.com', '2023-05-25'),
(14, 1, 'Gaby', 'Wyman', '223-237-8417', 'gwymand@hp.com', '2023-05-25'),
(15, 1, 'Mattie', 'Saw', '195-340-4044', 'msawe@squidoo.com', '2023-05-25'),
(16, 1, 'Nanete', 'Iddiens', '546-895-4914', 'niddiensf@google.com.br', '2023-05-25'),
(17, 1, 'Rafe', 'Corneille', '791-542-5631', 'rcorneilleg@bigcartel.com', '2023-05-25'),
(18, 1, 'Cassandre', 'Jozefczak', '173-698-3656', 'cjozefczakh@vimeo.com', '2023-05-25'),
(20, 2, 'Josefina', 'Claw', '463-368-2897', 'jclawj@ucla.edu', '2023-05-25'),
(21, 1, 'Janet', 'Jolin', '882-928-4103', 'jjolin0@sun.com', '2023-05-25'),
(22, 1, 'Billie', 'Sikorsky', '166-345-9894', 'bsikorsky1@google.com', '2023-05-25'),
(23, 1, 'Alistair', 'Jannex', '615-615-2772', 'ajannex2@cisco.com', '2023-05-25'),
(24, 1, 'Phoebe', 'Judgkins', '201-341-3823', 'pjudgkins3@tiny.cc', '2023-05-25'),
(25, 1, 'Hymie', 'Bazely', '964-611-4471', 'hbazely4@live.com', '2023-05-25');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `login`
--

INSERT INTO `login` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin'),
(2, 'Jaime', '123456789'),
(3, 'Jose', 'Jose1'),
(4, 'angel21', 'angel25');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `login_id` int(11) NOT NULL,
  `nombres` varchar(10) NOT NULL,
  `apellidos` varchar(10) NOT NULL,
  `correos` varchar(30) NOT NULL,
  `numeros` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `login_id`, `nombres`, `apellidos`, `correos`, `numeros`) VALUES
(1, 2, 'Jaime Alex', 'Suarez Viv', 'Jaime@gmail.com', '+505 89406'),
(2, 3, 'Jose ', 'Perez', 'Jose@gmail.com', '+505 87505'),
(3, 4, 'Jose angel', 'Mercado', 'angel@gmail.com', '+505 89485');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contactos`
--
ALTER TABLE `contactos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `direccion` (`correos`),
  ADD UNIQUE KEY `numeros` (`numeros`),
  ADD KEY `login_id` (`login_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contactos`
--
ALTER TABLE `contactos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=212;

--
-- AUTO_INCREMENT de la tabla `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contactos`
--
ALTER TABLE `contactos`
  ADD CONSTRAINT `contactos_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`login_id`) REFERENCES `login` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
