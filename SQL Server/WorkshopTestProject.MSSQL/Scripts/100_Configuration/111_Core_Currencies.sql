/* core.Currency hinzufügen */
SET IDENTITY_INSERT [core].[Currency] ON;
MERGE INTO [core].[Currency] AS Target 
USING (VALUES 
(1, 'AED', 'Dirham', '100 Fils', 'Vereinigte Arabische Emirate'),
(2, 'AFN', 'Neuer Afghani', '100 Puls', 'Afghanistan'),
(3, 'ALL', 'Lek', '100 Quindarka', 'Albanien'),
(4, 'AMD', 'Dram', '100 Luma', 'Armenien'),
(5, 'ANG', 'Gulden', '100 Cents', 'Niederländische Antillen'),
(6, 'AOA', 'Kwanza', '100 Centimos', 'Angola'),
(7, 'ARS', 'Peso', '100 Centavos', 'Argentinien'),
(8, 'AUD', 'Australischer Dollar', '100 Cents', 'Australien'),
(9, 'AWG', 'Aruba-Florin', '100 Cents', 'Aruba'),
(10, 'AZM', 'Manat', '100 Gapik', 'Aserbaidschan'),
(11, 'BAM', 'Konvertible Mark', '100 Konvertible Pfennig', 'Bosnien und Herzegowina'),
(12, 'BBD', 'Dollar', '100 Cents', 'Barbados'),
(13, 'BDT', 'Taka', '100 Poisha', 'Bangladesch'),
(14, 'BGN', 'Lew', '100 Stotinki', 'Bulgarien'),
(15, 'BHD', 'Dinar', '1000 Fils', 'Bahrain'),
(16, 'BMD', 'Dollar', '100 Cents', 'Bermuda'),
(17, 'BND', 'Dollar (Ringgit)', '100 Cents (Sen)', 'Brunei'),
(18, 'BOB', 'Boliviano', '100 Centavos', 'Bolivien'),
(19, 'BRL', 'Real', '100 Centavos', 'Brasilien'),
(20, 'BSD', 'Dollar', '100 Cents', 'Bahamas'),
(21, 'BWP', 'Pula', '100 Thebe', 'Botsuana'),
(22, 'BYR', 'Rubel', '100 Kopeken', 'Weißrussland (Belarus)'),
(23, 'BZD', 'Dollar', '100 Cents', 'Belize'),
(24, 'BZN', 'Ngultrum', '100 Chhetrum', 'Bhutan'),
(25, 'CAD', 'Dollar', '100 Cents', 'Kanada'),
(26, 'CDF', 'Franc', '100 Centimes', 'Demokratische Republik Kongo'),
(27, 'CHF', 'Franken', '100 Rappen', 'Schweiz'),
(28, 'CLP', 'Peso', '100 Centavos', 'Chile'),
(29, 'CNY', 'Renminbi Yuan', '10 Jiao = 100 Fen', 'China (Volksrepublik)'),
(30, 'COP', 'Peso', '100 Centavos', 'Kolumbien'),
(31, 'CRC', 'Colón', '100 Céntimos', 'Costa Rica'),
(32, 'CSD', 'Dinar', '100 Para', 'Serbien'),
(33, 'CUP', 'Peso', '100 Centavos', 'Kuba'),
(34, 'CVE', 'Escudo', '100 Centavos', 'Kap Verde'),
(35, 'CYP', 'Pfund', '100 Cents', 'Zypern (griechischer Teil)'),
(36, 'CZK', 'Krone', '100 Heller', 'Tschechien'),
(37, 'DJV', 'Franc', '100 Centimes', 'Dschibuti'),
(38, 'DKK', 'Krone', '100 Öre', 'Dänemark'),
(39, 'DOP', 'Peso', '100 Centavos', 'Dominikanische Republik'),
(40, 'DZD', 'Dinar', '100 Centimes', 'Algerien'),
(41, 'ECS', 'Sucre', '100 Centavos', 'Ecuador (bis 2000)'),
(42, 'EEK', 'Krone', '100 Senti', 'Estland'),
(43, 'EGP', 'Pfund', '100 Piaster', 'Ägypten'),
(44, 'ETB', 'Birr', '100 Santeem', 'Äthiopien'),
(45, 'EUR', 'Euro', '100 Cent', 'Europäische Währungsunion'),
(46, 'FJD', 'Dollar', '100 Cent', 'Fidschi'),
(47, 'FKP', 'Pfund', '100 Pence', 'Falklandinseln'),
(48, 'GBP', 'Pfund', '100 Pence', 'Vereinigtes Königreich'),
(49, 'GEL', 'Lari', '100 Tetri', 'Georgien'),
(50, 'GHC', 'Cedi', '100 Pesewas', 'Ghana'),
(51, 'GIP', 'Pfund', '100 Pence', 'Gibraltar'),
(52, 'GMD', 'Dalasi', '100 Bututs', 'Gambia'),
(53, 'GNF', 'Franc', '', 'Guinea'),
(54, 'GTQ', 'Quetzal', '100 Centavo', 'Guatemala'),
(55, 'GYD', 'Dollar', '100 Cent', 'Guyana'),
(56, 'HKD', 'Dollar', '100 Cent', 'Hongkong'),
(57, 'HNL', 'Lempira', '100 Centavo', 'Honduras'),
(58, 'HRK', 'Kuna', '100 Lipa', 'Kroatien'),
(59, 'HTG', 'Gourde', '100 Centimes', 'Haiti'),
(60, 'HUF', 'Forint', '100 Filler', 'Ungarn'),
(61, 'IDR', 'Rupiah', '100 Sen', 'Indonesien'),
(62, 'ILS', 'Schekel', '100 Agorot', 'Israel'),
(63, 'INR', 'Rupie', '100 Paise', 'Indien'),
(64, 'IQD', 'Dinar', '1000 Fils', 'Irak'),
(65, 'IRR', 'Rial', '100 Dinars', 'Iran'),
(66, 'ISK', 'Krone', '100 Aurar', 'Island'),
(67, 'JMD', 'Dollar', '100 Cents', 'Jamaika'),
(68, 'JOD', 'Dinar', '100 Piaster = 1000 Fils', 'Jordanien'),
(69, 'JPY', 'Yen', '100 Sen', 'Japan'),
(70, 'KES', 'Schilling', '100 Cents', 'Kenia'),
(71, 'KGS', 'Som', '100 Tyiyn', 'Kirgisistan'),
(72, 'KHR', 'Riel', '10 Kak = 100 Sen', 'Kambodscha'),
(73, 'KMF', 'Franc', '100 Centimes', 'Komoren'),
(74, 'KPW', 'Won', '100 Chon', 'Nordkorea'),
(75, 'KRW', 'Won', '100 Chon', 'Südkorea'),
(76, 'KWD', 'Dinar', '1000 Fils', 'Kuwait'),
(77, 'KYD', 'Dollar', '100 Cents', 'Kaimaninseln'),
(78, 'KZT', 'Tenge', '100 Tiyn', 'Kasachstan'),
(79, 'LAK', 'Kip', '100 Att', 'Laos'),
(80, 'LBP', 'Pfund', '100 Piaster', 'Libanon'),
(81, 'LKR', 'Rupie', '100 Cents', 'Sri Lanka'),
(82, 'LRD', 'Dollar', '100 Cents', 'Liberia'),
(83, 'LSL', 'Loti', '100 Lisente', 'Lesotho'),
(84, 'LTL', 'Litas', '100 Centas', 'Litauen'),
(85, 'LVL', 'Lats', '100 Santim', 'Lettland'),
(86, 'LYD', 'Dinar', '1000 Dirham', 'Libyen'),
(87, 'MAD', 'Dirham', '100 Centimes', 'Marokko'),
(88, 'MDL', 'Leu', '100 Bani', 'Moldawien'),
(89, 'MGA', 'Ariary', '5 Iraimbilanja', 'Madagaskar'),
(90, 'MKD', 'Denar', '100 Deni', 'Mazedonien'),
(91, 'MMK', 'Kyat', '100 Pyas', 'Myanmar'),
(92, 'MNT', 'Tögrög', '100 Möngö', 'Mongolei'),
(93, 'MOP', 'Pataca', '100 Avos', 'Macau'),
(94, 'MRO', 'Ouguiya', '5 Khoums', 'Mauretanien'),
(95, 'MTL', 'Lira', '100 Cents', 'Malta'),
(96, 'MUR', 'Rupie', '100 Cents', 'Mauritius'),
(97, 'MVR', 'Rufiyaa', '100 Laari', 'Malediven'),
(98, 'MWK', 'Kwacha', '100 Tambala', 'Malawi'),
(99, 'MXN', 'Peso', '100 Centavos', 'Mexiko'),
(100, 'MYR', 'Ringgit', '100 Sen', 'Malaysia'),
(101, 'MZM', 'Metical', '100 Centavos', 'Mosambik'),
(102, 'NAD', 'Dollar', '100 Cents', 'Namibia'),
(103, 'NGN', 'Naira', '100 Kobo', 'Nigeria'),
(104, 'NIO', 'Córdoba Oro', '100 Centavos', 'Nicaragua'),
(105, 'NOK', 'Krone', '100 Öre', 'Norwegen'),
(106, 'NPR', 'Rupie', '100 Paisa', 'Nepal'),
(107, 'NZD', 'Dollar', '100 Cents', 'Neuseeland'),
(108, 'OMR', 'Rial', '1000 Baiza', 'Oman'),
(109, 'PAB', 'Balboa', '100 Centésimos', 'Panama'),
(110, 'PEN', 'Nuevo Sol', '100 Céntimos', 'Peru'),
(111, 'PGK', 'Kina', '100 Toeau', 'Papua-Neuguinea'),
(112, 'PHP', 'Peso', '100 Centavos', 'Philippinen'),
(113, 'PKR', 'Rupie', '100 Paisa', 'Pakistan'),
(114, 'PLN', 'Zloty', '100 Groszy', 'Polen'),
(115, 'PYG', 'Guaraní', '100 Céntimos', 'Paraguay'),
(116, 'QAR', 'Riyal', '100 Dirham', 'Katar'),
(117, 'ROL', 'Leu', '100 Bani', 'Rumänien'),
(118, 'RUB', 'Rubel', '100 Kopeken', 'Russland'),
(119, 'RWF', 'Franc', '100 Centimes', 'Ruanda'),
(120, 'SAR', 'Riyal', '20 Qirsch = 100 Halala', 'Saudi-Arabien'),
(121, 'SBD', 'Dollar', '100 Cents', 'Salomonen'),
(122, 'SCR', 'Rupie', '100 Cents', 'Seychellen'),
(123, 'SDD', 'Dinar', '100 Piaster', 'Sudan'),
(124, 'SEK', 'Krone', '100 Öre', 'Schweden'),
(125, 'SGD', 'Dollar', '100 Cents', 'Singapur'),
(126, 'SHP', 'Pfund', '100 Pence', 'St. Helena'),
(127, 'SIT', 'Tolar', '100 Stotin', 'Slowenien'),
(128, 'SKK', 'Krone', '100 Heller', 'Slowakei'),
(129, 'SLL', 'Leone', '100 Cents', 'Sierra Leone'),
(130, 'SOS', 'Schilling', '100 Centesimi', 'Somalia'),
(131, 'SRD', 'Dollar', '100 Cents', 'Suriname'),
(132, 'STD', 'Dobra', '100 Céntimos', 'São Tomé und Príncipe'),
(133, 'SVC', 'Colón', '100 Centavos', 'El Salvador'),
(134, 'SYP', 'Pfund', '100 Piaster', 'Syrien'),
(135, 'SZL', 'Lilangeni', '100 Cents', 'Swasiland'),
(136, 'THB', 'Baht', '100 Satang', 'Thailand'),
(137, 'TJS', 'Somoni', '100 Diram', 'Tadschikistan'),
(138, 'TMM', 'Manat', '100 Tenge', 'Turkmenistan'),
(139, 'TND', 'Dinar', '1000 Millimes', 'Tunesien'),
(140, 'TOP', 'Paanga', '100 Seniti', 'Tonga'),
(141, 'TRL', 'Lira', '100 Kuru', 'Türkei'),
(142, 'TRY', 'Neue Lira', '100 Neue Kuru', 'Türkei'),
(143, 'TTD', 'Dollar', '100 Cents', 'Trinidad und Tobago'),
(144, 'TWD', 'Dollar', '10 Jiao = 100 Fen', 'Taiwan'),
(145, 'TZS', 'Schilling', '100 Cents', 'Tansania'),
(146, 'UAH', 'Hrywnja', '100 Kopijka', 'Ukraine'),
(147, 'UGX', 'Shilling', '100 Cents', 'Uganda'),
(148, 'USD', 'Dollar', '100 Cents', 'USA'),
(149, 'UYU', 'Peso', '100 Centésimos', 'Uruguay'),
(150, 'UZS', 'So´m', '100 Tiyin', 'Usbekistan'),
(151, 'VEB', 'Bolivar', '100 Céntimos', 'Venezuela'),
(152, 'VND', 'Dong', '10 Hào = 100 Xu', 'Vietnam'),
(153, 'VUV', 'Vatu', 'keine', 'Vanuatu'),
(154, 'WST', 'Tala', '100 Sene', 'Samoa'),
(155, 'XAF', 'CFA-Franc', '100 Centimes', 'Zentralafrikanische Wirtschafts- und Währungsunion'),
(156, 'XCD', 'Dollar', '100 Cents', 'Ostkaribische Währungsunion'),
(157, 'XOF', 'CFA-Franc', '100 Centimes', 'Westafrikanische Wirtschafts- und Währungsunion'),
(158, 'XPF', 'CFP-Franc', 'keine', 'Neukaledonien'),
(159, 'YER', 'Rial', '100 Fils', 'Jemen'),
(160, 'ZAR', 'Rand', '100 Cent', 'Südafrika'),
(161, 'ZMK', 'Kwacha', '100 Ngwee', 'Sambia'),
(162, 'ZWD', 'Dollar', '100 Cents', 'Simbabwe'),
(163, 'FBU', 'Burundi-Franc', '100 Centimes', 'Burundi'),
(164, 'ECD', 'Ostkaribischer Dollar', '100 Cents', 'Dominica'),
(165, 'NFA', 'Nakfa', '100 Cents', 'Eritrea'),
(166, 'NIS', 'Neuer Schekel', '100 Agorot', 'Palästinensische Gebiete')
) 
AS Source (CurId, Iso, Currency, CurrencyParts, Region) 
ON Target.Id = Source.CurId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id]
        ,[ModifiedDate]
        ,[ModifiedUser]
        ,[Iso]
        ,[Currency]
        ,[CurrencyParts]
        ,[Region])
VALUES (CurId
        ,'2017-01-01 00:00:00.0000'
        ,1
        ,Source.Iso
        ,Source.Currency
        ,Source.CurrencyParts
        ,Source.Region)
WHEN MATCHED THEN 
    UPDATE 
        SET [ModifiedDate] = '2017-01-01 00:00:00.0000'
           ,[ModifiedUser] = 1
           ,[Iso] = Source.Iso
           ,[Currency] = Source.Currency
           ,[CurrencyParts] = Source.CurrencyParts
           ,[Region] = Source.Region;
SET IDENTITY_INSERT [core].[Currency] OFF;