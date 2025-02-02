--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-11-07 09:49:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4893 (class 0 OID 27074)
-- Dependencies: 217
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "Fullname", "Address", "DoB", "IsDeleted", "CreateAt", "UpdateAt", "Specialization", "StartDate", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
e0e147ab-7fce-4859-b208-2d552210ec2b	Nguyễn An Nhiên	141 Đường Sen	1984-10-12 00:00:00	f	2024-11-06 15:37:47.412672	2024-11-06 15:37:47.412672	\N	\N	nhien.an@example.com	NHIEN.AN@EXAMPLE.COM	nhien.an@example.com	NHIEN.AN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEKgMaStUgM/yBt9h9hbSJaJSulEjDK2l7DEYFTnG/A++RFp0uYrwQrnyK5aG3tzqQQ==	4LVNBZQAN2FJ7G6YVAHBKLL5TTJXAFIM	9d4cb432-af60-49f0-9874-a2854854b11e	0123456701	f	f	\N	t	0
e41c8b65-9629-44f9-8b9a-5e61323aacd7	Trần Hà Phương	152 Đường Hoa	1990-05-14 00:00:00	f	2024-11-06 15:37:48.391321	2024-11-06 15:37:48.391321	\N	\N	Haphuong.ha@example.com	HAPHUONG.HA@EXAMPLE.COM	Haphuong.ha@example.com	HAPHUONG.HA@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEI2ghXzrAUKojQQJ3BazT3bs9BVx4eDqQ9NR3B8UupweA/zm8+xSS7Bp2eb6gK0nWQ==	JFUYZOZ3QXSOXNPQ2QBGJ3WBXWNVT45X	29149c74-61f3-458f-b3d5-729e36067712	0123456702	f	f	\N	t	0
3bba9fd6-c07b-450f-a8e4-4adccb032270	Lê Kiên Cường	163 Đường Lê	1992-07-29 00:00:00	f	2024-11-06 15:37:48.621907	2024-11-06 15:37:48.621907	\N	\N	Kiencuong.kiens@example.com	KIENCUONG.KIENS@EXAMPLE.COM	Kiencuong.kiens@example.com	KIENCUONG.KIENS@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEHMJydjGxUXu/Ud4+FfHXnHDfviQsRLuN8FSfT4Fae+OmD/kMVPS8laxGD/g/bcRXQ==	HP56ITCKPP3OZNNJ56HZW3IRWI7GLUBI	2b924973-66d5-4f87-8fa1-d7ed76819f27	0123456703	f	f	\N	t	0
420b1d72-cc7b-4904-aca5-2ef0aba30d11	Phạm Tuấn Minh	174 Đường Đào	1988-02-18 00:00:00	f	2024-11-06 15:37:48.98555	2024-11-06 15:37:48.98555	\N	\N	tuann.minh@example.com	TUANN.MINH@EXAMPLE.COM	tuann.minh@example.com	TUANN.MINH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEOtmPM0COIPCXWe7N7WyhAZMcmeNXSz8V/EVf3U6CFZxkgN+z50vYV43zVU2rpg6Kw==	RDHMIVLYFLTEEZZ6NTOPPCRAUP5MK2JM	36126b42-742a-4897-87f2-aaac471c1555	0123456704	f	f	\N	t	0
816ebdf9-b63e-452a-84ff-ab6e522fe269	Vũ Hồng Diễm	185 Đường Ngọc	1995-01-11 00:00:00	f	2024-11-06 15:37:49.194754	2024-11-06 15:37:49.194754	\N	\N	dien.hong@example.com	DIEN.HONG@EXAMPLE.COM	dien.hong@example.com	DIEN.HONG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAECt2fkioG3Y7+AAehpiEeLuXOrujpHSgYvpjpnkYG/e56W+MgELgfjezoOc2y4Iz9w==	YIY254Q4XQCPVZBXSHYTPTMA4P7ICD45	d6f8cf1b-9ac6-43f6-8ac9-38a33fac2c80	0123456705	f	f	\N	t	0
bc6d9d67-81a5-4e2b-a67a-e62e2bfa56c7	Đỗ Ngọc Lan	196 Đường Tùng	1991-03-22 00:00:00	f	2024-11-06 15:37:49.566525	2024-11-06 15:37:49.566525	\N	\N	lan.ngoc@example.com	LAN.NGOC@EXAMPLE.COM	lan.ngoc@example.com	LAN.NGOC@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEB/2EjAnHpYsblolT2hIzOZL5pna66UEQbms4RuuUxdFcnKpqn+EgdFENJJLIxG1Bg==	IY5LDJBR4ENU2QO3F5MA5LQPQYA7UOOT	3028e65e-998f-4885-89f6-8aa3150af682	0123456706	f	f	\N	t	0
c16902d4-ccb8-4244-adc5-2e5233d8d13c	Bùi Phúc Lộc	207 Đường Bạch	1987-09-13 00:00:00	f	2024-11-06 15:37:49.885475	2024-11-06 15:37:49.885475	\N	\N	loc.phuc@example.com	LOC.PHUC@EXAMPLE.COM	loc.phuc@example.com	LOC.PHUC@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELJRgWM1q9C4z5fJVUqoFXdkXFemxO5bdYMh82Qw559Bj+S1VmU0KSRgPffvczgPnQ==	3KWYPTMWD6IUC3NXVMGGPDKGOGPN6WS4	4db7d6b2-4b43-4303-8006-d42df0bfe532	0123456707	f	f	\N	t	0
aa37dae0-4956-4307-951f-524d2253298b	Hoàng Nguyên Đạt	218 Đường Hải	1983-06-30 00:00:00	f	2024-11-06 15:37:50.108925	2024-11-06 15:37:50.108925	\N	\N	dat.nguyen@example.com	DAT.NGUYEN@EXAMPLE.COM	dat.nguyen@example.com	DAT.NGUYEN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEI4tuomMUs4z6D8hCIJOCOLRk+1ci+UzU/DsxPb6x+7YG/S0Kunvi9p5KZuSQ1tWew==	3BGSXQUE5UKFQ7UJBVMHXMGEIY3UPZF3	7d22dcb7-3120-4346-88ec-ae263bdfc7a0	0123456708	f	f	\N	t	0
de0928ea-f417-4dec-a607-a49b566fcb21	Nguyễn Kim Tuyến	229 Đường Thủy	1989-12-08 00:00:00	f	2024-11-06 15:37:50.459973	2024-11-06 15:37:50.459973	\N	\N	tuyen.kim@example.com	TUYEN.KIM@EXAMPLE.COM	tuyen.kim@example.com	TUYEN.KIM@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEBg5MYIL7NgavvIhcXpQigdI/iY1HkjminETkPPhGCANhQxcw1QLSehGEQ585oLRRg==	ZNTFGMSYC5OY6W4PY3EWHNJC3LOOQ57O	9bc86fba-48ed-484a-bcce-ad206e7cf644	0123456709	f	f	\N	t	0
71e2d214-0f05-4ab7-9131-a157553e68a9	Trần Bảo Anh	230 Đường Khê	1985-04-15 00:00:00	f	2024-11-06 15:37:50.754714	2024-11-06 15:37:50.754714	\N	\N	anh.bao@example.com	ANH.BAO@EXAMPLE.COM	anh.bao@example.com	ANH.BAO@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEGV1O5Ii4o2gztLGqnrgnqfc/TP2yyvrPtMsrrJ+So5EcVsykkISGnfdszH03CxOfQ==	GUA7XTT4CDJOM3AREQRJRRYRNR7OPYWY	2b843316-ce4b-4673-aba4-73f1f7830f0c	0123456710	f	f	\N	t	0
1e278106-5053-4432-8a1d-547885f9c93a	Lê Việt Hưng	241 Đường Phúc	1990-08-21 00:00:00	f	2024-11-06 15:37:51.111179	2024-11-06 15:37:51.111179	\N	\N	hung.viet@example.com	HUNG.VIET@EXAMPLE.COM	hung.viet@example.com	HUNG.VIET@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEGqPTBLQla8yxiIc4lJyN0mJUttPLymzAWsKwf3meeWflbTlGDlmKdiSuLH+Im6aYg==	PLOLJFKHAI5XSLX6LCEOMF3ZVACJLNQA	94be4f5b-629f-4e75-8803-bf3b89c414b5	0123456711	f	f	\N	t	0
68a00be2-5819-46ad-b12e-bf3d832458e6	Phạm Thanh Hòa	252 Đường An	1993-02-05 00:00:00	f	2024-11-06 15:37:51.332468	2024-11-06 15:37:51.332468	\N	\N	hoa.thanh@example.com	HOA.THANH@EXAMPLE.COM	hoa.thanh@example.com	HOA.THANH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEE8FyuwguFdgs6Ta5rsEVaHrOJJMdYnNy3plmi0rCn4YakfaV5Pdt+Iv/vMjM88tZA==	ZOFBMF7FFMAKRXMBZZIDHQ4U7OD33SWF	5a982d08-a168-4823-87d7-edf6e80ac219	0123456712	f	f	\N	t	0
1bda526c-b5bc-4968-927a-4f0bc809ab1e	Vũ Minh Khánh	263 Đường Ngân	1994-11-03 00:00:00	f	2024-11-06 15:37:51.611699	2024-11-06 15:37:51.611699	\N	\N	khanh.minh@example.com	KHANH.MINH@EXAMPLE.COM	khanh.minh@example.com	KHANH.MINH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELZbjKzj2uFdwHmrIl/nyUWNn4RuPhtZyunObyWFvu82V/6F+Ndvb+3bx0xCTfhBsA==	7RA5JAD2KNKBTESSON4ZQQLWGIT7B5TN	077fd1bb-9cbc-4070-aa12-d7fd62f7e956	0123456713	f	f	\N	t	0
39265d84-df44-462e-a796-0c342281011d	Đỗ Quang Hải	274 Đường Quế	1982-01-20 00:00:00	f	2024-11-06 15:37:51.829465	2024-11-06 15:37:51.829465	\N	\N	hai.quang@example.com	HAI.QUANG@EXAMPLE.COM	hai.quang@example.com	HAI.QUANG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEMrV4wnSdSj1N/xkslUtxqSPDed4JDMqu/XTMf7pK2pYVrC/yM6EmEV4gRcCXUyDUQ==	JIGAG2EZ6QU2GPLYW3AN52LUPX7PFVM5	ab46d0db-d839-4ead-9329-02ff2d3e2031	0123456714	f	f	\N	t	0
4b8e045b-f717-4d8b-976c-e990e4722124	Bùi Tú Anh	285 Đường Hạnh	1986-03-27 00:00:00	f	2024-11-06 15:37:52.165377	2024-11-06 15:37:52.165377	\N	\N	anh.tu@example.com	ANH.TU@EXAMPLE.COM	anh.tu@example.com	ANH.TU@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELulXW60tw+gYNFhinUnc8tty+R8aOX516Irw2OqB1Z6NxbKbu/ms/0Pjgh79kto9Q==	GXSVZ27CQQFCPOEENG6SVYVBRU46HJTV	edb18874-07bc-4e84-afb4-9664079f727d	0123456715	f	f	\N	t	0
cf684dbf-0c4f-40d2-847b-88e7a9968f14	Hoàng Duy Linh	296 Đường Thủy	1991-07-15 00:00:00	f	2024-11-06 15:37:52.427368	2024-11-06 15:37:52.427368	\N	\N	linh.duy@example.com	LINH.DUY@EXAMPLE.COM	linh.duy@example.com	LINH.DUY@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEFMLwyOwQGldPMno5Idoub0p1Wx2nwdl/z9Sn0Ob49P/RT6UdEJuAx7J+h/Fu9KZFw==	3XCNURQKIU2QWGOOHRO656MGWCIMOS7T	2d4da5b3-a490-4cb2-917b-8000ab9780b4	0123456716	f	f	\N	t	0
df99c4f1-0985-41e8-825a-964adef28e0c	Nguyễn Tâm Đan	307 Đường Phượng	1995-05-12 00:00:00	f	2024-11-06 15:37:52.796313	2024-11-06 15:37:52.796313	\N	\N	dan.tam@example.com	DAN.TAM@EXAMPLE.COM	dan.tam@example.com	DAN.TAM@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEEo72rSn9BFFhE45jGsomFa05HeytSSY/SW72CoANCeGH3raKA7ky1vGbSVU2g8PuQ==	K3XHVT4I3AHKWVXDCKIFJMFNV7OSLMGU	13093241-25c2-4306-94ce-6198be0c3ded	0123456717	f	f	\N	t	0
2c9ff35f-8ec2-498b-8c02-87b272a2afec	Trần Hữu Tâm	318 Đường Mai	1984-09-26 00:00:00	f	2024-11-06 15:37:53.12087	2024-11-06 15:37:53.12087	\N	\N	tam.huu@example.com	TAM.HUU@EXAMPLE.COM	tam.huu@example.com	TAM.HUU@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEFeb9DuYpYE8JUIi9RgJjrDIktOP5C+ef2a6Gx8VxPlYsFl7HjVKmDSQXp0saW8XIg==	ACYYUUPRU7RFLJEQAK5NPTRHZG3F52RY	3f6f254e-4e30-42a1-bab1-920a934cc044	0123456718	f	f	\N	t	0
869962c9-f404-4913-abdc-d998e5537163	Lê Thắng	329 Đường Lộc	1988-10-02 00:00:00	f	2024-11-06 15:37:53.466172	2024-11-06 15:37:53.466172	\N	\N	thang.le@example.com	THANG.LE@EXAMPLE.COM	thang.le@example.com	THANG.LE@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEDYp6IcwY1yr7H4QsxMv61RCo8b47mcZM+S8CA9oFfd6suPXu28/bXJRZUCl11uVdw==	Y427HWEWHDELSANEBYUXJLKWSCNMHD6T	ee8e11a0-2c95-4e42-998f-12d8020e6aa7	0123456719	f	f	\N	t	0
df559399-613f-4562-83eb-87b12b0a0e78	Phạm Văn Sơn	330 Đường Tố	1992-06-28 00:00:00	f	2024-11-06 15:37:53.813188	2024-11-06 15:37:53.813188	\N	\N	sang.van@example.com	SANG.VAN@EXAMPLE.COM	sang.van@example.com	SANG.VAN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEA+d7DeOiQuqCf4lnQQopmLHKXA1qwsmwwD9kpLbTmhefmRtFtOMUoE4IYZFMIIYcA==	Z2QXUNENGYR3OLYSQ4UTFSVEQGAOKVOV	56d6aa94-bef3-4fe2-bce1-0cfb1fd06db7	0123456720	f	f	\N	t	0
a0941fb1-2df1-4b33-85a1-87abf012d7dd	Vũ Như Quỳnh	341 Đường Tâm	1996-04-17 00:00:00	f	2024-11-06 15:37:54.152101	2024-11-06 15:37:54.152101	\N	\N	quynh.nhu@example.com	QUYNH.NHU@EXAMPLE.COM	quynh.nhu@example.com	QUYNH.NHU@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEE8ZgOMu0thi0BbTddGPJoUE213EGPx9kk3IbNtG4tIrQ9toc6q7eMGu5D7pNRunmQ==	SLPM6PAZS3PX24KLQJGSSRN5K44SOI2A	d5f2f46f-24fe-4f11-bfd0-1d74eeedfe10	0123456721	f	f	\N	t	0
0bd283e0-c088-4eef-9c16-1a44c92cdf57	Đỗ Chí Tâm	352 Đường Sương	1991-08-25 00:00:00	f	2024-11-06 15:37:54.513268	2024-11-06 15:37:54.513268	\N	\N	tam.chi@example.com	TAM.CHI@EXAMPLE.COM	tam.chi@example.com	TAM.CHI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEMzY7t7p44aG+KnKlR0XH4ADmUd2nnXSiRxSuf90LiUcghanjQ453iSeIl4TO/ykzg==	HSIII6YMMOSMJ56R33OCWYJJ7QW3DI7R	13007e59-e89b-4898-988a-40369bad178e	0123456722	f	f	\N	t	0
97f26527-9de3-4222-ae7d-ff85f99a273e	Bùi Kim Chi	363 Đường Nắng	1985-01-14 00:00:00	f	2024-11-06 15:37:54.85304	2024-11-06 15:37:54.85304	\N	\N	chi.kim@example.com	CHI.KIM@EXAMPLE.COM	chi.kim@example.com	CHI.KIM@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEIw7vC+0b45olnKHg30G4GZhNRLuXuqju7GcXgBntQEx8RYhoDQgjh5c+pnpkMjqqA==	QDIKQXMIY56L6ZDEYVXXF3KP3UXE3WIY	08a5dde2-841f-4a29-8732-cfed8601f9c6	0123456723	f	f	\N	t	0
50af40f0-9df8-4b93-9f47-e2e57788cc54	Hoàng Vĩnh Phú	374 Đường Hạ	1993-03-11 00:00:00	f	2024-11-06 15:37:55.173341	2024-11-06 15:37:55.173341	\N	\N	phu.vinh@example.com	PHU.VINH@EXAMPLE.COM	phu.vinh@example.com	PHU.VINH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEAm3gjXIhJhm6zEwOPofySavMgYdqxTuI3OrFXpP2wPda9Z9GnTSJ8z3rosdhJBcBg==	QB3DWHJQEPGU5N6JUF5D4A3UZBOP27PD	ec2711d9-efe4-4952-9516-34b0f45b4d36	0123456724	f	f	\N	t	0
e666a755-60b7-4574-b9f7-99acf40ca5be	Nguyễn Xuân Hương	385 Đường Bồ	1987-12-21 00:00:00	f	2024-11-06 15:37:55.507501	2024-11-06 15:37:55.507501	\N	\N	huong.xuan@example.com	HUONG.XUAN@EXAMPLE.COM	huong.xuan@example.com	HUONG.XUAN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEB4+Qr19hBHrjts+3NBCVhSQjekg7kWjXunLbqoGipoh8mbWfXGsmzdeYe1fxXIukg==	NH4YOSGGMYAGAPVNEGOXK2XYAP3IE752	fc2981f3-aafc-4d9b-8971-f45e777b50d5	0123456725	f	f	\N	t	0
98901cfa-cece-4af3-a25b-3d7b9e0c4753	Trần Ngọc Quyên	396 Đường Mưa	1990-05-09 00:00:00	f	2024-11-06 15:37:55.724452	2024-11-06 15:37:55.724452	\N	\N	quyen.ngoc@example.com	QUYEN.NGOC@EXAMPLE.COM	quyen.ngoc@example.com	QUYEN.NGOC@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEO37Dd44YIL1mkbKPhcsavsg6Ydm6MhOZ9aLJd2fQFiJwn3vWS/lMPVat0cI2hukyg==	VI7546W4E6H35PEXWE5ELWMSM3DT2SFJ	b4e3572e-1b79-401d-8162-52e4e10dfb38	0123456726	f	f	\N	t	0
3f56337a-18c6-4587-afd4-a3a43e3e7b2f	Lê Thái Vương	407 Đường Ngọc	1989-10-15 00:00:00	f	2024-11-06 15:37:55.948596	2024-11-06 15:37:55.948596	\N	\N	vuong.thai@example.com	VUONG.THAI@EXAMPLE.COM	vuong.thai@example.com	VUONG.THAI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEMrl03CsOKHoLci2BW9NLceW0ZwtRoyfHz0w78QcX4wKHtZ5YTCYGhkVjnU9PQIl/Q==	JNUCND2VR34KAZOFX4HNRC2RDYNKJ2NU	4e4ef975-3ff3-4c56-b1c2-e661acafd669	0123456727	f	f	\N	t	0
0b37603c-345c-4d08-a949-db19b28cb6ab	Phạm Khải Hoàn	418 Đường Cúc	1982-07-03 00:00:00	f	2024-11-06 15:37:56.22672	2024-11-06 15:37:56.22672	\N	\N	hoan.khai@example.com	HOAN.KHAI@EXAMPLE.COM	hoan.khai@example.com	HOAN.KHAI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEG9Zgk6McdZNs8rzWqdibpDmgbruk4KlDLu0YKsI7ygnhxYny+oNQfw/+SgTuEK0Bg==	3PXCMIEYLF5E2MSPNH3MQI4Y4UKL6BRY	e593d3a6-1cfd-48cb-aa96-f1b300c7f407	0123456728	f	f	\N	t	0
f30fc040-4089-4926-8647-8885123b65c1	Vũ Thùy Linh	429 Đường Thế	1994-03-20 00:00:00	f	2024-11-06 15:37:56.451547	2024-11-06 15:37:56.451547	\N	\N	linh.thuy@example.com	LINH.THUY@EXAMPLE.COM	linh.thuy@example.com	LINH.THUY@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELVH/p3P3CjFsbyntyNTWLpZbYnfvQNjQN0Dd1jc/Er64ta3JvR6o7Qrg6p1B2YH3w==	WLKM2VXITK7H35VK2IHI54JDZCK37IA3	e10b38f6-50e7-43e4-a6d0-7677f4161985	0123456729	f	f	\N	t	0
16f724ae-c56f-4def-bce5-1d6138fc8b9a	Đỗ Khánh Huy	430 Đường Châu	1991-01-01 00:00:00	f	2024-11-06 15:37:56.684753	2024-11-06 15:37:56.684753	\N	\N	huy.khanh@example.com	HUY.KHANH@EXAMPLE.COM	huy.khanh@example.com	HUY.KHANH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEMVdzOq+5tJzm3+6FyFOcpzBlg0u6izqez/pO4aHDXtSBZSTMK78MZAUV5mGxujb/g==	5VXZPG57PRRWTA4OZPZ4FVCFXOXNNWVM	8c35c64c-083c-4c50-a516-368502286fbe	0123456730	f	f	\N	t	0
69b80109-dcc0-4e3e-bf2c-402369dcf264	Tuấn Tú	441 Đường Mộc	1988-04-23 00:00:00	f	2024-11-06 15:37:56.943479	2024-11-06 15:37:56.943479	\N	\N	tu.tu@example.com	TU.TU@EXAMPLE.COM	tu.tu@example.com	TU.TU@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEBju0YzkihED1E1mwEUzuaOvDxYsVoqFta/DjMLTA5Gyfcvwimn0oVPTP8I7QNVCKw==	RSH6LH62L6IRMXDWN7GZBC3B4ZSLNWND	4c5329e6-87c2-46be-8454-dfb38f7a022c	0123456731	f	f	\N	t	0
aabe2932-7b7a-4e09-906f-cd255b6ff07a	Hải Đăng	452 Đường Biển	1995-09-04 00:00:00	f	2024-11-06 15:37:57.168842	2024-11-06 15:37:57.168842	\N	\N	dang.hai@example.com	DANG.HAI@EXAMPLE.COM	dang.hai@example.com	DANG.HAI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEHBHRwbYI/3ITEWgAfiTO9gZd1h7/sZqN/SuO6vDAKiEekgTyM0SqJrPEnYKbw2vtA==	HZFJ6M64WO6EFLZWHNHMNQML6GGTAAF5	dcd855a6-ec09-4cc5-91d0-0278b287fa70	0123456732	f	f	\N	t	0
9824e4a5-0e48-4833-8117-02172fa85e95	Tuyết Nhung	463 Đường Sài	1986-06-17 00:00:00	f	2024-11-06 15:37:57.38514	2024-11-06 15:37:57.38514	\N	\N	gia.tuyet@example.com	GIA.TUYET@EXAMPLE.COM	gia.tuyet@example.com	GIA.TUYET@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEDl6sbtiwWDBoXGqeiVDSjYp52X94NNYhg5/WzjaLRjUrPKnKuUbPViL6rZhlQQHVA==	62PPDG4LXOEW5FX2VVNHVS5XTQCF3FRO	a15e0fc1-06dd-4d3f-9316-6559fa1f4e9f	0123456733	f	f	\N	t	0
7e953b92-971f-49ed-b023-dd2bd2ecdff4	Hạnh Dung	474 Đường Đồng	1983-08-08 00:00:00	f	2024-11-06 15:37:57.615492	2024-11-06 15:37:57.615492	\N	\N	dung.hanh@example.com	DUNG.HANH@EXAMPLE.COM	dung.hanh@example.com	DUNG.HANH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEIBlzv03zuAcJ47jIj9AXboWPsw9/Z17o42d/ZHRFDwgkAFxnffyaXOfJVi+7pbO6g==	TZ57D2ZET77ZZIMFDSCEDUNBYD23MK6W	7419a6ef-f173-432b-9fe5-f0d0685ad08b	0123456734	f	f	\N	t	0
f5c3af71-8fd7-416c-8469-2c81258054d4	Đăng Khoa	485 Đường Hương	1990-07-29 00:00:00	f	2024-11-06 15:37:57.83562	2024-11-06 15:37:57.83562	\N	\N	khoa.dang@example.com	KHOA.DANG@EXAMPLE.COM	khoa.dang@example.com	KHOA.DANG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEEkGhXVvAFn88Y69ntQDM3cxSRBX/37cqF55HIxTLvr3Bcw8cb0vWXusuRbqdwPNSw==	H2D2DZ7VTPC3WP74HBVN3PAFJBV2WOLB	09a783cc-ed03-42c1-980d-b019736d04d4	0123456735	f	f	\N	t	0
75767b7f-a921-4d71-9f45-ded29835e81b	Cẩm Ngọc	496 Đường Trà	1989-12-31 00:00:00	f	2024-11-06 15:37:58.100231	2024-11-06 15:37:58.100231	\N	\N	ngoc.cam@example.com	NGOC.CAM@EXAMPLE.COM	ngoc.cam@example.com	NGOC.CAM@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEIKGJg9o4KXvcQTBSstFjJ9mCNmofRO1KTlzUCxDf/hUjkGOHgQuOgOD5TkT2z289A==	I4KUJEOPLQRA3LKQNSEGFTYYEAUJ6CTH	8422e62a-eac9-44d2-ab0b-f53e906b99e7	0123456736	f	f	\N	t	0
49adce5c-d393-4d56-beb4-800d6b9f4c4f	Như Ý	507 Đường Sen	1994-05-12 00:00:00	f	2024-11-06 15:37:58.442611	2024-11-06 15:37:58.442611	\N	\N	y.nhu@example.com	Y.NHU@EXAMPLE.COM	y.nhu@example.com	Y.NHU@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEGYF4pa1YVC0qmS3sz2rF/RFFRvTtceokwRHJZ+k3YdenHy+R8vk6WTfKLWzJ2AFdg==	QI3KISUULYJ4LPN4XFFPRHXAR3KT2QW3	ab458f97-0aec-4d9d-93f1-31fa38220bbc	0123456737	f	f	\N	t	0
f4211892-2d33-48c6-9b93-04ab3fba15f2	Ngân Lê	123 Đường Sen	1980-12-25 00:00:00	f	2024-11-06 15:38:26.859975	2024-11-06 15:38:26.859975	Kiểm tra sức khỏe tổng quát	2024-01-01 00:00:00	ngan.le@example.com	NGAN.LE@EXAMPLE.COM	ngan.le@example.com	NGAN.LE@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEFJMULrQbvf/NZcjXSrKiPjX7xOS1fesTmwKVTgDZsnToUMZGMQGcmj2FD1RAVsrFQ==	GVME6KLYUGGTBQVBRH5YQXV6AB6PZJF6	2f33a4e1-3644-452d-8905-62e628d868f9	0123456781	f	f	\N	t	0
bcafe5f1-4ec3-4cb5-8de4-40e8a5d90e87	Thùy Trang	456 Đường Hoa	1995-06-15 00:00:00	f	2024-11-06 15:38:27.787451	2024-11-06 15:38:27.787451	Xét nghiệm da liễu	2024-01-01 00:00:00	thuy.trang@example.com	THUY.TRANG@EXAMPLE.COM	thuy.trang@example.com	THUY.TRANG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEGxsqVmGkPSR3AmMFyTEEUm+d8HVIvKArVpUxlcx/6mICnLDvBZS8P8JPF5g1iTRFw==	N7P3NCKS4SGWPAERLSSPGQHU5DWSBHQL	2aca7ab1-5521-4b51-a428-c0d504a5074b	0123456782	f	f	\N	t	0
caf45385-b507-4376-88c3-a7fd513446c1	Minh Hằng	789 Đường Phong	1988-03-12 00:00:00	f	2024-11-06 15:38:27.969262	2024-11-06 15:38:27.969262	Xét nghiệm cơ xương khớp	2024-01-01 00:00:00	h.minh@example.com	H.MINH@EXAMPLE.COM	h.minh@example.com	H.MINH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELl1FeuQf4Ndrg7GdAl3y2W79fzJvlmEzGuDyHvwsZh1d54E+RvFMIICMGbfHDNizQ==	Z4S5Z4KWQCL4E7O5SI25TSI2XZY3XAFL	01d73eb2-38de-4502-933a-8e37f97d6599	0123456783	f	f	\N	t	0
543a2abb-7ddf-4ef5-a757-5a6d7a538cb1	Hoàng Nam	101 Đường Tùng	1985-02-20 00:00:00	f	2024-11-06 15:38:28.17715	2024-11-06 15:38:28.17715	Xét nghiệm tuyến giáp	2024-01-01 00:00:00	nam.hoang@example.com	NAM.HOANG@EXAMPLE.COM	nam.hoang@example.com	NAM.HOANG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEHYUnv/7CXWHbhXIJ3zW8W2Qos5DgB0hngKiLg0bXytkaFfbfwU3sBNBiRG5S8IJwQ==	OKEXMB33GIY7XKDGZJSQ3HNOM2YPSF4B	5f3aef08-722b-470f-beff-01d43ff812b7	0123456784	f	f	\N	t	0
2c3f5257-1080-4f2b-83f6-9b81cc95e21b	Bích Ngọc	202 Đường Bạch	1990-07-30 00:00:00	f	2024-11-06 15:38:28.44146	2024-11-06 15:38:28.44146	Xét nghiệm thai lưu	2024-01-01 00:00:00	ngoc.bich@example.com	NGOC.BICH@EXAMPLE.COM	ngoc.bich@example.com	NGOC.BICH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEBxFW/mfkbLsK23ElOx7j26Qlfy9GwYAqR+8twrN7g/dNlqMMBkvEb7jzPrQh+quZQ==	LJY2ZALP4CGZ3PRH3SUJVJUN7JYY4QZG	3e475116-74e6-4629-82de-5ae5e667f4a7	0123456785	f	f	\N	t	0
5af086da-71c5-4e86-a2a9-3f4ef5480946	Thanh Tùng	303 Đường Hương	1982-11-14 00:00:00	f	2024-11-06 15:38:28.715125	2024-11-06 15:38:28.715125	Kiểm tra định kì viêm gan B	2024-01-01 00:00:00	tung.thanh@example.com	TUNG.THANH@EXAMPLE.COM	tung.thanh@example.com	TUNG.THANH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAECJYC+nnyffw5RShFSi3UBihf+07nKwaLwHgnxd3PG5WqvKwWfNTXk16x69VRCdVyw==	RPYIYDBV7TNPYRQK2B7DWH4CAIBT5TIM	06bec1a2-2321-4727-b96e-62fd9d1bb3eb	0123456786	f	f	\N	t	0
bc69491a-856b-4254-82cf-a025bf87aaca	Hải Yến	404 Đường Cúc	1993-04-22 00:00:00	f	2024-11-06 15:38:28.944009	2024-11-06 15:38:28.944009	Chăm sóc người bệnh không lây nhiễm	2024-01-01 00:00:00	yen.hai@example.com	YEN.HAI@EXAMPLE.COM	yen.hai@example.com	YEN.HAI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEHrVG8JjkG8tnH6mMXEztsR6ElrUe+d5RmfUXyusDihVFQtSnfvTGBMTHjKGDhg4Pw==	TPDRXCBYRYXIL4HG7PEQN4STFPA6X5VW	cc77d2f9-b5c3-4c65-8ec5-5fa685c44610	0123456787	f	f	\N	t	0
524265b7-fd64-48b1-abc6-3845aee24892	Phương Anh	505 Đường Phượng	1986-09-18 00:00:00	f	2024-11-06 15:38:29.281296	2024-11-06 15:38:29.281296	Vật lý trị liệu và phục hồi chức năng	2024-01-01 00:00:00	anh.phuong@example.com	ANH.PHUONG@EXAMPLE.COM	anh.phuong@example.com	ANH.PHUONG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEJURTn4HrPh2VIlUIhsQqRb8tQDtW92TulMXpLaXyWEsyPXn1IctjZMyUbbolSBBlw==	EN5PIP6VM4PN752ZY4PMP5BX5AGNMALN	20971c19-0027-4562-aeab-2a07a082914b	0123456788	f	f	\N	t	0
6bf214e6-070d-465c-93cf-3dc95200b96f	Đức Dũng	606 Đường Đào	1989-01-07 00:00:00	f	2024-11-06 15:38:29.641519	2024-11-06 15:38:29.641519	Chăm sóc người lớn tuổi	2024-01-01 00:00:00	dung.duc@example.com	DUNG.DUC@EXAMPLE.COM	dung.duc@example.com	DUNG.DUC@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEORnIb9gCxH+XyETYOOkZoDumOMusb4RxianhrTDZkfqmnAaFF6yYGeaODB+ZJ7k/w==	OSPCINUUAMX3PZUGAK2BHOWAPA4CWGDX	1de1de6a-368a-492c-9d95-c453d6a88f60	0123456789	f	f	\N	t	0
4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	Mai Linh	707 Đường Ngọc	1992-05-19 00:00:00	f	2024-11-06 15:38:29.858887	2024-11-06 15:38:29.858887	Khám vi chất trẻ em	2024-01-01 00:00:00	linh.mai@example.com	LINH.MAI@EXAMPLE.COM	linh.mai@example.com	LINH.MAI@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEPyeGcW1hMRslpPh56WkGnbj/rwoAzfJaymaqiFir1BARLQPA5Dilm3ft9ISB5Sl3g==	TVVOEUZ255NJN32QSVJDXPRTMN6CR4W7	8a9bc7d4-aea9-4e41-b2ce-7a0c2e8659f3	0123456790	f	f	\N	t	0
af4018af-d3d1-4fed-a300-4da5dae2c298	Bảo Khánh	808 Đường Lê	1987-08-28 00:00:00	f	2024-11-06 15:38:30.176343	2024-11-06 15:38:30.176343	Chăm sóc sau phẫu thuật	2024-01-01 00:00:00	khanh.bao@example.com	KHANH.BAO@EXAMPLE.COM	khanh.bao@example.com	KHANH.BAO@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEBrgwzkEThPrB9u70/uZRSaKuQH+AiaIr/wXObLD/JpGtRf8l5zsfwS8lMj2oQ3rqA==	KPQTFD3N47QJQQTYWTJZGT6GFALYDNKB	3a78b7cf-a89c-4d57-bd9d-8702503202b4	0123456791	f	f	\N	t	0
12c58190-f166-4c7f-9201-e86e620e5707	Hồng Phúc	909 Đường Quế	1991-10-10 00:00:00	f	2024-11-06 15:38:30.385912	2024-11-06 15:38:30.385912	Tầm soát ung thư toàn diện	2024-01-01 00:00:00	phuc.hong@example.com	PHUC.HONG@EXAMPLE.COM	phuc.hong@example.com	PHUC.HONG@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEDupJbgpIpT/K3+aWeabbAE4HlFPw9gQjbDnYjoiICoK5tvTuv5XRD6XIf33w5FlBg==	RQ57F46HHI57EUZ2Q2NOQTO5MJ6FXXHD	264bcab4-a376-40ff-89e2-e3ebc160ce29	0123456792	f	f	\N	t	0
5c19e7cd-e7fb-42d5-9851-d090679d94fb	Lan Hương	1010 Đường Mai	1983-12-12 00:00:00	f	2024-11-06 15:38:30.677479	2024-11-06 15:38:30.677479	Kiểm tra sức khỏe tổng quát	2024-01-01 00:00:00	huong.lan@example.com	HUONG.LAN@EXAMPLE.COM	huong.lan@example.com	HUONG.LAN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEDiids+CXu66uesJ8LOac3WFVoL8pnHtjP+5e1v+jitkcbjqmflFhucUC9CqkG92ow==	LIRRU5VX5GUNRIKRKTTZZJ5PLVEAOMXF	bd417512-6a2f-4702-948a-b90065af83c8	0123456793	f	f	\N	t	0
394b8335-a0f4-4730-996f-4426c5806358	Thảo Vy	1111 Đường Bồ	1985-03-23 00:00:00	f	2024-11-06 15:38:30.934701	2024-11-06 15:38:30.934701	Xét nghiệm da liễu	2024-01-01 00:00:00	vy.thao@example.com	VY.THAO@EXAMPLE.COM	vy.thao@example.com	VY.THAO@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEN2yfbxS1jxsNMfxSWgSZCR7wrAqTv++U+jss0eqgrk3AsKQZvio2G4ey3lx+PD9JA==	SNOU423ET2V2EGWN3AHYHQTZNCNVGHGS	d46c0bcd-90ae-422e-aa0c-52d47739d963	0123456794	f	f	\N	t	0
c4183601-41cc-429b-ae54-bc5057b91153	Lê Duy	1212 Đường Trúc	1994-11-05 00:00:00	f	2024-11-06 15:38:31.284923	2024-11-06 15:38:31.284923	Xét nghiệm cơ xương khớp	2024-01-01 00:00:00	duy.le@example.com	DUY.LE@EXAMPLE.COM	duy.le@example.com	DUY.LE@EXAMPLE.COM	f	AQAAAAIAAYagAAAAELGMwutxQlnywWc7G8nr6QX6P0OhkHoimZoP6d0aJUQ5r9hlOkBjcH1nTl/uB0qixA==	IULLRO4THFCY52BJ3FIDUC24FXCPSVAK	2818b0da-a509-4a68-8827-77fb9b9cb312	0123456795	f	f	\N	t	0
3d7ccf2e-e0f1-4363-8126-c1f477c6870a	An Bình	1313 Đường Sen	1990-02-14 00:00:00	f	2024-11-06 15:38:31.49785	2024-11-06 15:38:31.49785	Xét nghiệm tuyến giáp	2024-01-01 00:00:00	binh.an@example.com	BINH.AN@EXAMPLE.COM	binh.an@example.com	BINH.AN@EXAMPLE.COM	f	AQAAAAIAAYagAAAAECyLRIuLtMsd7xwhdPtUn44ffgJq9NG0bvSidrKTFF75GH+jnppuCktlmVkHkz2xKw==	3G2FDUM4TYSKPP4EP3QYM6CP3T6FEEN4	b33d2d64-678f-432f-8316-6e8cfb7e698c	0123456796	f	f	\N	t	0
6df68a87-bbf7-4ae9-acf6-a646c111e946	Cẩm Nhung	1414 Đường Liễu	1982-06-07 00:00:00	f	2024-11-06 15:38:31.72205	2024-11-06 15:38:31.72205	Xét nghiệm thai lưu	2024-01-01 00:00:00	nhung.cam@example.com	NHUNG.CAM@EXAMPLE.COM	nhung.cam@example.com	NHUNG.CAM@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEAKhymXhfoBSlxsQE/9pd5yjyPZHIvlZev4oSb8OpVs1nWIcqvN9XJOFCsB0HT2R/w==	3TLNGVPUJ5S5ZTCIWBTIH7QOULBTTLGU	fc100457-5405-45f6-9f5c-0186fd38fb57	0123456797	f	f	\N	t	0
e3d5af7d-4f91-4419-8b98-585aeb01f88a	Linh Chi	1515 Đường Hoa	1996-07-21 00:00:00	f	2024-11-06 15:38:32.0909	2024-11-06 15:38:32.0909	Kiểm tra định kì viêm gan B	2024-01-01 00:00:00	chi.linh@example.com	CHI.LINH@EXAMPLE.COM	chi.linh@example.com	CHI.LINH@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEFwZ45nWW0lpGw3FbZyzJbWpz5VLPlqdvwlwpW1oTC5S3wG/TPtUb2d4CEp5X/jt7Q==	T6XW55NK4EPMXLF36NASZGPKQYPMF7LA	24d37c75-a7fb-458a-b84c-ab812c6c381c	0123456798	f	f	\N	t	0
e58b2a65-4eb9-4f0c-8ffc-de335c3732ce	Quốc Huy	1616 Đường Thạch	1988-09-17 00:00:00	f	2024-11-06 15:38:32.440832	2024-11-06 15:38:32.440832	Chăm sóc người bệnh không lây nhiễm	2024-01-01 00:00:00	huy.quoc@example.com	HUY.QUOC@EXAMPLE.COM	huy.quoc@example.com	HUY.QUOC@EXAMPLE.COM	f	AQAAAAIAAYagAAAAEK7SWL0pfSLjRsaXmSh4CzoRw5BOJCcuBMU4Nk/bASWgyqAzjI0N+w+HLi9+EYCttQ==	FTSKDKL4FIMKQNBS4C3BVQXNJQLXYBGP	f3b6c8ff-0e3e-4eab-806f-f17007a12d23	0123456799	f	f	\N	t	0
2d0f2ee7-50ce-41b8-813d-8fa55c0cc2e0	Ngân Lê Thị Hoàng	123	2002-11-06 00:00:00	f	2024-11-06 15:52:41.110361	2024-11-06 15:52:41.110361	\N	\N	lthngan662@gmail.com	LTHNGAN662@GMAIL.COM	lthngan662@gmail.com	LTHNGAN662@GMAIL.COM	f	AQAAAAIAAYagAAAAENTjezGR9Rz9n2JmL6a+3XNlTxkBbtrzlyjzlQYfKTbjgh76b27p6QiANPUj5n+7fQ==	EXY4E3YUKFF3Z42W5FXRLWQIMLJRLUJG	b28692a6-38ff-40e6-b55f-d2f78ad11e54	0132123123	f	f	\N	t	0
\.


--
-- TOC entry 4897 (class 0 OID 27092)
-- Dependencies: 221
-- Data for Name: ServiceTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ServiceTypes" ("Id", "Name", "Description", "IsActive", "Image") FROM stdin;
1	Kiểm tra sức khỏe tổng quát	Đánh giá các bệnh lý về máu (huyết học): thiếu máu, bất thường về sự sản xuất các dòng tế bào hồng cầu, bạch cầu, tiểu cầu, giúp sàng lọc các bệnh máu ác tính (ung thư các dòng tế bào máu)\r\nBộ đôi sàng lọc và chẩn đoán bệnh đái tháo đường (tiểu đường). Glucose: Chỉ số đường máu lúc đói. HbA1C (Chỉ số đường máu trung bình 3 tháng gần thời điểm xét nghiệm)\r\nBộ xét nghiệm kiểm tra men gan, đánh giá chức năng gan, tình trạng tổn thương tế bào gan do các nguyên nhân như: viêm gan, viêm gan do virus, viêm gan do rượu, do nhiễm độc…\r\nBộ xét nghiệm cơ bản đánh giá chức năng thận, cầu thận\r\nBộ xét nghiệm đánh giá tình trạng chuyển hóa lipid máu (chuyển hóa mỡ máu, cao mỡ máu), đánh giá mức độ cao mỡ máu, --> thay đổi chế độ ăn uống luyện tập, dùng thuốc, dự phòng nguy cơ biến chứng trầm trọng: đột quy tim (nhồi máu cơ tim), đột quỵ não (tai biến mạch não)\r\nXét nghiệm đánh giá lượng Acid uric, phát hiện tình trạng tăng acid uric, mức độ tăng acid uric --> thực hiện chế độ ăn uống hợp lý để hạn chế mưc độ tăng, dự phòng nguy cơ diễn biến thành bệnh Gout trong tương lai, dự phòng nguy cơ khởi phát cơn Gout cấp lặp lại (với người đã bị Gout)\r\nKhuyến cáo:\r\n- Dành cho NAM & NỮ giới từ 16 tuổi trở lên\r\n- Đặc biệt là những người ở độ tuội cận trung niên, trung niên đã hoặc đang mắc các bệnh lý mãn tính như: Đái tháo đường, Tăng huyết áp, Rối loạn chuyển hóa mỡ máu.	t	/images/servicetypes/a0137be5-a8f0-4454-99e6-01bc25d1d7fc.png
2	Xét nghiệm da liễu	"Đánh giá tình trạng thiếu máu, viêm nhiễm\r\nĐánh giá mức độ viêm nhiễm trong cơ thể, chỉ ra tình trạng viêm khớp cấp tính.\r\nĐánh giá chức năng gan, để tiên lượng việc sử dụng thuốc\r\nĐánh giá lượng độc tố dư thừa trong tế bào gan\r\nĐánh giá chức năng thận, để sử dụng thuốc cho phù hợp\r\nPhát hiện sớm các bệnh dị ứng và phản ứng quá mẫn của cơ thể\r\nXác định nguyên nhân dị ứng mà còn có thể phòng ngừa dị ứng trong tương lai.\r\nPhát hiện các kí sinh trùng thường gặp gây bệnh lí về da, đường ruột,..gây các triệu chứng nổi mẩn ngứa, đỏ da"	t	/images/servicetypes/d62dfb4d-55ef-4572-99e1-cc0a39af2721.png
3	Xét nghiệm cơ xương khớp	"Đánh giá tình trạng viêm trong viêm khớp…\r\nĐánh giá mức độ viêm nhiễm trong cơ thể, chỉ ra tình trạng viêm khớp cấp tính.\r\nĐánh giá chức năng gan, để tiên lượng việc sử dụng thuốc\r\nĐánh giá lượng độc tố dư thừa trong tế bào gan\r\nĐánh giá chức năng thận, để sử dụng thuốc cho phù hợp\r\nĐánh giá tình trạng loãng xương\r\nTheo dõi tình trạng viêm\r\nChẩn đoán các bệnh lí liên quan tới yếu tố dạng thấp gồm các triệu chứng đau sưng khớp bất thường không rõ nguyên nhân,cứng khớp,kèm sốt mệt mỏi,.. trong các bệnh lí viêm khớp dạng thấp, lupus ban đỏ,..\r\nChẩn đoán các bệnh lí liên quan tới đau sưng khớp,.. trong các bệnh lí nhiễm khuẩn, gút,..\r\nChẩn đoán các bệnh lí gồm các triệu chứng đau sưng khớp, cứng khớp,.. trong các bệnh lí như viêm cột sống cứng khớp, viêm khớp dạng thấp thiếu niên, viêm khớp phản ứng, ..\r\nPhát hiện các tổn thương trên xương: gai xương, loãng xương,..\r\nXác định hàm lượng canxi và các khoáng chất có trong xương. Những khu vực thường được thực hiện đo mật độ xương là cột sống, hông hoặc xương cẳng tay"\r\n	t	/images/servicetypes/99192df7-ba36-4961-9a1a-ad32955367b9.png
4	Xét nghiệm tuyến giáp	"Đánh giá tình trạng thiếu máu, kiểm tra các tế bào dòng bạch cầu, hồng cầu, tiểu cầu để sàng lọc các bệnh về máu …\r\nMen gan, đánh giá, tiên lượng 1 phần hoạt động của chức năng gan,\r\nĐánh giá lượng độc tố dư thừa trong tế bào gan\r\nChẩn đoán bệnh lý về thận như: Suy thận…\r\nĐánh giá chức năng tuyến giáp\r\nĐánh giá bệnh lý tuyến giáp: viêm tuyến giáp, basedow,...\r\nĐánh giá ung thư tuyến giáp thể biệt hóa\r\nĐánh giá ung thư tuyến giáp thể tủy\r\nĐánh giá phát hiện nang, nhân, kích thước bất thường của 2 thùy tuyến giáp\\"\r\n	t	/images/servicetypes/0d1aa02c-074a-4dca-ac00-73b7b07534bb.png
5	Xét nghiệm thai lưu	"Thăm khám và đánh giá với bs chuyên khoa Sản, tư vấn kết quả, kê đơn\r\nĐánh giá tổng quan 3 dòng tế bào máu, tình trạng thiếu máu, sàng lọc bệnh lý về máu: thalasemia...\r\nXác định nhóm máu mẹ, dự phòng bất đồng nhóm máu mẹ con\r\nMen gan, đánh giá, tiên lượng 1 phần hoạt động của chức năng gan,\r\nĐánh giá sự bài tiết dịch mật, giúp tiên lượng 1 phần chức năng gan\r\nĐánh giá lượng độc tố dư thừa trong tế bào gan\r\nChẩn đoán bệnh lý về thận như: Suy thận…\r\nChẩn đoán bệnh lý tiểu đường và theo dõi điều trị\r\nĐánh giá chức năng tuyến giáp\r\nĐánh giá tình trạng sắt huyết thanh trong cơ thể, xác định nguyên nhân gây bệnh lý thiếu máu thiếu sắt\r\nĐánh giá nội tiết cơ bản, cần cho sự phát triển, phóng noãn và làm tổ của thai\r\nĐánh giá chức năng dự trữ của buồng trứng, chẩn đoán bệnh buồng trứng đa nang\r\nĐánh giá bất thường bộ NST về số lượng và cấu trúc\r\nPhát hiện kháng thể, hội chứng Anti Phospholipid gây thai lưu, sảy thai liên tiếp...\r\nSàng lọc gen gây tăng đông, chỉ tình trạng mà một người dễ hình thành các huyết khối ( cục máu đông) trong tĩnh mạch và động mạch\r\nĐánh giá tình trạng viêm nhiễm hệ tiết niệu, 1 phần bệnh lý về thận, gan…\r\nĐánh giá bất thường của tuyến vú( nhân xơ, u xơ tuyến vú, nang…)\r\nĐánh giá kích thước, phát hiện 1 số bất thường của tuyến giáp ( Nhân, nang tuyến giáp)\r\nĐánh giá cấu trúc, phát hiện bất thường của phần phụ"\r\n	t	/images/servicetypes/98dbb3d3-7ec5-4806-8e6b-8780d97c0723.png
6	Kiểm tra định kì viêm gan B	"Đánh giá tình trạng thiếu máu, kiểm tra các tế bào dòng bạch cầu, hồng cầu, tiểu cầu để sàng lọc các bệnh về máu …\r\nMen gan, đánh giá, tiên lượng 1 phần hoạt động của chức năng gan,\r\nĐánh giá lượng độc tố dư thừa trong tế bào gan\r\nĐánh giá sự bài tiết dịch mật, giúp tiên lượng 1 phần chức năng gan\r\nĐánh giá rối loạn đông máu\r\nĐánh giá chức năng tổng hợp của gan\r\nChẩn đoán bệnh lý về thận như: Suy thận…\r\nĐánh giá sự hoạt động của virus viêm gan B\r\nĐếm tải lượng virus viêm gan B\r\nTầm soát ung thư gan\r\nChẩn đoán ung thư biểu mô tế bào gan\r\nĐánh giá bất thường tạng trong ổ bụng (gan, thận, tụy, lách,…)\r\nĐánh giá độ xơ hóa của gan\r\nĐánh giá đáp ứng điều trị"\r\n	t	/images/servicetypes/2bc9061d-c6fc-428c-88eb-38d4a6821a55.png
7	Chăm sóc người bệnh không lây nhiễm	"Khi bạn có nhu cầu về chăm sóc sức khỏe mà không thể đi đến các trung tâm y tế dù là gần nhất. Hãy liên lạc WorldHealth, với đội ngũ điều dưỡng giàu kinh nghiệm, được đào tạo bài bản, có chứng chỉ hành nghề, tận tâm và chuyên nghiệp, chúng tôi cam kết chăm sóc người bệnh, giúp bệnh nhân mau chóng bình phục và người nhà an tâm gửi gắm.\r\n- Cho bệnh nhân ăn uống.\r\n- Vệ sinh bệnh nhân\r\n- Xoa bóp vùng đau nhức, vỗ rung.\r\n- Nâng trở bệnh nhân.\r\n- Theo dõi mạch, nhiệt độ, huyết áp.\r\n- Hỗ trợ giám sát bệnh nhân uống thuốc theo đơn.\r\n- vv...vv..."\r\n	t	/images/servicetypes/1a7ff752-46ed-490b-bf72-3875ac857f67.png
8	Vật lý trị liệu và phục hồi chức năng	"Vật lý trị liệu và Phục hồi chức năng là quá trình đặc biệt quan trọng dành những cho bệnh nhân trong quá trình phục hồi sức khỏe sau khi nằm viện điều trị dài ngày hay sau phẫu thuật do chấn thương, hoặc những bệnh nhân điều trị khối U khi về nhà mà sức khỏe yếu, chức năng vận động bị hạn chế do nằm lâu bất động trong một thời gian dài.\r\nTại WorldCare, đội ngũ điều dưỡng giàu kinh nghiệm, được đào tạo bài bản, có chứng chỉ hành nghề, tận tâm và chuyên nghiệp. Chúng tôi cam kết chăm sóc người bệnh một cách tận tình, giúp bệnh nhân mau chóng bình phục đem lại sự an tâm cho người nhà khi gửi gắm."\r\n	t	/images/servicetypes/937dbed6-54b8-4c4c-897d-a8a40bbbb0ef.jpg
9	Chăm sóc người lớn tuổi	"Cuộc sống bộn bề, đôi khi con cái không có đủ thời gian toàn tâm chăm sóc cha mẹ một cách toàn diện, đặc biệt là khi người thân đau ốm. Thấu hiểu và đồng cảm với những băn khoăn này, dịch vụ chăm sóc người già của WorldHealth để giúp một phần cho các con chăm sóc cha mẹ vào những khoảng thời gian bận rộn, giúp người thân bạn luôn đảm bảo sức khỏe về thể chất và sự vui vẻ về mặt tinh thần.\r\n- Trông nom, chăm sóc bệnh nhân.\r\n- Cho bệnh nhân ăn uống.\r\n- Vệ sinh bệnh nhân\r\n- Xoa bóp vùng đau nhức, vỗ rung.\r\n- Nâng trở bệnh nhân.\r\n- Vận chuyển người bệnh.\r\n- vv...vv..."\r\n	t	/images/servicetypes/6917c8dd-71c6-4d0d-8a1d-1cd1ca1d1111.jpg
10	Khám vi chất trẻ em	"Đánh giá tình trạng thiếu máu, kiểm tra các tế bào dòng bạch cầu, hồng cầu, tiểu cầu để sàng lọc các bệnh về máu …\r\nMen gan, đánh giá hoạt động của chức năng gan\r\nChẩn đoán bệnh lý về thận như: Suy thận…\r\nĐánh giá rối loạn đường máu trong cơ thể\r\nĐÁNH GIÁ TÌNH TRẠNG SUY DINH DƯỠNG\r\nĐịnh lượng Calci toàn phần trong máu\r\nĐịnh lượng các ion (Na, K, CL) điện giải \r\nKiểm tra và chẩn đoán thiếu magie trong máu\r\nChẩn đoán nguyên nhân thiếu máu, Thiếu vitamin B12 hoặc folate đều có thể gây thiếu máu nguyên hồng cầu khổng lồ\r\nĐánh giá tình trạng thiếu hoặc thừa kẽm trong cơ thể\r\nĐánh giá tình trạng thiếu hụt hoặc dư thừa vtm D để chẩn đoán còi xương, loãng xương, …\r\n: Chẩn đoán nguyên nhân thiếu máu, Thiếu vitamin B12 hoặc folate đều có thể gây thiếu máu nguyên hồng cầu khổng lồ\r\nLà enzym có nhiều ở gan, xương, nhau thai và biểu mô ruột. Tăng trong: Loãng xương, còi xương, u xương, gãy xương\r\nHormone chẩn đoán, đánh giá hoạt động của chức năng tuyến giáp\r\nKiểm tra nhóm máu\r\nĐánh giá tình trạng viêm nhiễm hệ tiết niệu, 1 phần bệnh lý về thận, gan…\r\nKhám và tư vấn, kết luận tổng quát."\r\n	t	/images/servicetypes/abc930bf-63f5-4228-9d46-9732738d9041.png
11	Chăm sóc sau phẫu thuật	Dịch vụ này cung cấp sự chăm sóc đặc biệt cho bệnh nhân vừa trải qua phẫu thuật. Nhân viên y tế sẽ hỗ trợ quá trình phục hồi bao gồm thay băng, kiểm tra vết mổ, quản lý đau, và hỗ trợ sinh hoạt hàng ngày. Với dịch vụ này, bệnh nhân sẽ được theo dõi và chăm sóc một cách an toàn và hiệu quả ngay tại nhà mà không cần phải đến bệnh viện thường xuyên.\r\n	t	/images/servicetypes/035873fb-7b40-4dba-ac20-46e845411750.jpg
12	Tầm soát ung thư toàn diện	"Khám với bác sĩ chuyên khoa Nội, Sản\r\nXác định nhóm máu\r\nĐánh giá tình trạng thiếu máu, kiểm tra các tế bào dòng bạch cầu, hồng cầu, tiểu cầu để sàng lọc các bệnh về máu …\r\nĐánh giá rối loạn đông máu\r\nMen gan, đánh giá, tiên lượng 1 phần hoạt động của chức năng gan,\r\nĐánh giá sự bài tiết dịch mật, giúp  tiên lượng 1 phần chức năng gan\r\nChẩn đoán bệnh lý về thận như: Suy thận…\r\nChẩn đoán bệnh lý tiểu đường\r\nĐánh giá tình trạng mỡ máu trong cơ thể, tiên lượng các nguy cơ đối với bệnh lý tim mạch, tụy…\r\nĐánh giá chuyển hóa trong cơ thể\r\nĐánh giá chức năng tuyến tụy\r\nĐánh giá men tim, men cơ\r\nĐánh giá nguy cơ một số bệnh lý tim mạch: suy tim, nhồi máu cơ tim\r\nĐánh giá huyết khối\r\nĐánh giá bệnh lý viêm khớp dạng thấp\r\nĐánh giá bệnh lý Gout\r\nĐánh giá tình trạng sắt huyết thanh trong cơ thể, xác định  nguyên nhân gây bệnh lý thiếu máu thiếu sắt \r\nĐánh giá tình trạng thiếu vi chất: kẽm, acid folat, magie, vitamin B12\r\nĐịnh lượng Calci toàn phần trong máu\r\nĐánh giá chức năng tuyến giáp\r\nĐịnh lượng các ion (Na, K,Cl)\r\nĐánh giá tổn thương thận sớm do bệnh lý tiểu đường,…\r\nĐánh giá tình trạng viêm nhiễm hệ tiết niệu, 1 phần bệnh lý về thận, gan…\r\nKiểm tra xem có bị viêm gan B hay không\r\nĐánh giá kháng thể viêm gan B\r\nKiểm tra xem có bị viêm gan B thể ẩn hay không\r\nKiểm tra xem có bị viêm gan C hay không\r\nKiểm tra xem có bị viêm gan A hay không\r\nKiểm tra xem có bị viêm gan E hay không\r\nKiểm tra xem có mắc HIV hay không\r\nĐánh giá kháng thể kháng Herpes\r\nKiểm tra xem có mắc giang mai không\r\nKiểm tra vi khuẩn Hp dạ dày\r\nĐánh giá nồng độ Testosterone\r\nDấu ấn tầm soát ung thư gan\r\nDấu ấn tầm soát ung thư đường tiêu hóa\r\nDấu ấn tầm soát ung thư dạ dày\r\nDấu ấn tầm soát ung thư tụy mật\r\nDấu ấn tầm soát ung thư tuyến giáp\r\nDấu ấn tầm soát ung thư phổi\r\nDấu ấn tầm soát ung thư tiền liệt tuyến\r\nDấu ấn tầm soát ung thư tế bào vảy\r\nĐánh giá bất thường tạng trong ổ bụng (gan, thận, tụy, lách,…)\r\nĐánh giá phát hiện nang, nhân, kích thước bất thường của 2 thùy tuyến giáp\r\nĐánh giá hình ảnh của tim, hoạt động của van tim, khả năng bơm máu cơ tim\r\nĐánh giá tình trạng viêm nhiễm bộ phận sinh dục\r\nĐánh giá phát hiện kích thước, vị trí,các bệnh lý của tinh hoàn…\r\nĐánh giá phát hiện kích thước, vị trí,các bệnh lý của tiền liệt tuyến…\r\nChẩn đoán phát hiện 12 loại vi khuẩn gây viêm đường tiết niệu: Chlamydia, Lậu, Mycoplasma, Gardnerella vaginalis, Ureaplasma parvum, Herpes, Giang mai,  Nấm Candida…\r\nĐánh giá thông khí phổi, chức năng hô hấp\r\nĐánh giá nhịp tim, theo dõi 1 số bệnh lý về tim mạch\r\nĐánh giá được huyết động của não cũng như những thay đổi trạng thái của chức năng mạch máu não\r\nPhát hiện bệnh lý Tai mũi họng\r\nPhát hiện các bệnh lý thực quản, dạ dày\r\nPhát hiện các bệnh lý đại trực tràng\r\nPhí gây mê nội soi dạ dày và đại trực tràng\r\nPhát hiện 1 số tổn thương tại phổi ( Viêm, Lao…\r\nGiúp rà soát, kiểm tra đặc điểm, cấu trúc của những cơ quan chính bên trong cơ thể từ đó phát hiện chính xác tổn thương, sự tồn tại hay tình trạng của khối u.\r\nĐánh giá bất thường bộ nhiễm sắc thể về số lượng , cấu trúc,…\r\nĐánh giá tình trạng loãng xương"\r\n	t	/images/servicetypes/fea6a69b-a368-440d-b47d-f5e54ad4015d.png
\.


--
-- TOC entry 4908 (class 0 OID 27175)
-- Dependencies: 232
-- Data for Name: ServicePackages; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ServicePackages" ("Id", "Name", "Price", "NumberOfSessions", "DurationInMonths", "IsActive", "ServiceTypeId") FROM stdin;
7	Gói 1 buổi	600000.00	1	1	t	3
8	Gói 4 buổi	2200000.00	4	1	t	3
9	Gói 12 buổi	6500000.00	12	3	t	3
10	Gói 1 buổi	500000.00	1	1	t	4
14	Gói xét nghiệm Doppler	4000000.00	3	2	t	5
12	Gói cơ bản	1200000.00	1	1	t	5
13	Gói nâng cao	2500000.00	2	1	t	5
15	Gói tổ hợp	7500000.00	5	3	t	5
16	Gói toàn diện	12000000.00	7	3	t	5
1	Gói 1 buổi	500000.00	1	1	t	1
2	Gói 4 buổi	1800000.00	4	1	t	1
3	Gói 12 buổi	5000000.00	12	3	t	1
4	Gói 1 buổi	400000.00	1	1	t	2
5	Gói 4 buổi	1500000.00	4	1	t	2
6	Gói 12 buổi	4200000.00	12	3	t	2
11	Gói 4 buổi	1800000.00	2	6	t	4
17	Gói 1 buổi	1500000.00	1	1	t	6
18	Gói 2 buổi	2800000.00	2	6	t	6
20	Gói 3 buổi	3500000.00	3	6	t	7
19	Gói 1 buổi	1200000.00	1	1	t	7
21	Gói 4 buổi	3000000.00	4	1	t	8
22	Gói 10 buổi	7000000.00	10	6	t	8
23	Gói 5 buổi	4000000.00	5	3	t	9
24	Gói 10 buổi	8500000.00	10	6	t	9
25	Gói 3 buổi	1700000.00	3	1	t	10
26	Gói 5 buổi	3000000.00	5	2	t	11
27	Gói 2 buổi	3000000.00	2	1	t	12
\.


--
-- TOC entry 4899 (class 0 OID 27100)
-- Dependencies: 223
-- Data for Name: Shifts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Shifts" ("Id", "Name", "StartTime", "EndTime") FROM stdin;
1	Ca 1	07:30:00	09:30:00
2	Ca 2	10:00:00	12:00:00
3	Ca 3	13:00:00	15:00:00
4	Ca 4	15:30:00	17:30:00
5	Ca 5	18:00:00	20:00:00
\.


--
-- TOC entry 4910 (class 0 OID 27188)
-- Dependencies: 234
-- Data for Name: Subscriptions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Subscriptions" ("Id", "PatientId", "ServicePackageId", "UsedSessions", "SubscriptionDate", "StartDate", "EndDate", "Total", "IsPaid", "PaymentDate", "Status") FROM stdin;
94	e0e147ab-7fce-4859-b208-2d552210ec2b	1	4	2023-04-15 00:00:00	2023-04-15 00:00:00	2023-05-15 00:00:00	500000.00	t	2023-04-15 00:00:00	2
95	e41c8b65-9629-44f9-8b9a-5e61323aacd7	1	4	2023-07-22 00:00:00	2023-07-22 00:00:00	2023-08-22 00:00:00	500000.00	t	2023-07-22 00:00:00	2
96	3bba9fd6-c07b-450f-a8e4-4adccb032270	1	4	2024-03-10 00:00:00	2024-03-10 00:00:00	2024-04-10 00:00:00	500000.00	t	2024-03-10 00:00:00	2
97	420b1d72-cc7b-4904-aca5-2ef0aba30d11	2	4	2023-05-18 00:00:00	2023-05-18 00:00:00	2023-06-18 00:00:00	1800000.00	t	2023-05-18 00:00:00	2
98	816ebdf9-b63e-452a-84ff-ab6e522fe269	2	4	2023-09-12 00:00:00	2023-09-12 00:00:00	2023-10-12 00:00:00	1800000.00	t	2023-09-12 00:00:00	2
99	bc6d9d67-81a5-4e2b-a67a-e62e2bfa56c7	3	4	2023-11-25 00:00:00	2023-11-25 00:00:00	2024-02-25 00:00:00	5000000.00	t	2023-11-25 00:00:00	2
100	c16902d4-ccb8-4244-adc5-2e5233d8d13c	14	4	2024-02-15 00:00:00	2024-02-15 00:00:00	2024-04-15 00:00:00	4000000.00	t	2024-02-15 00:00:00	2
101	aa37dae0-4956-4307-951f-524d2253298b	12	4	2024-06-10 00:00:00	2024-06-10 00:00:00	2024-07-10 00:00:00	1200000.00	t	2024-06-10 00:00:00	2
102	de0928ea-f417-4dec-a607-a49b566fcb21	13	4	2023-08-01 00:00:00	2023-08-01 00:00:00	2023-09-01 00:00:00	2500000.00	t	2023-08-01 00:00:00	2
103	71e2d214-0f05-4ab7-9131-a157553e68a9	15	4	2024-04-05 00:00:00	2024-04-05 00:00:00	2024-07-05 00:00:00	7500000.00	t	2024-04-05 00:00:00	2
104	1e278106-5053-4432-8a1d-547885f9c93a	16	4	2024-01-14 00:00:00	2024-01-14 00:00:00	2024-04-14 00:00:00	12000000.00	t	2024-01-14 00:00:00	2
105	68a00be2-5819-46ad-b12e-bf3d832458e6	1	4	2023-12-01 00:00:00	2023-12-01 00:00:00	2024-01-01 00:00:00	500000.00	t	2023-12-01 00:00:00	2
106	1bda526c-b5bc-4968-927a-4f0bc809ab1e	5	4	2023-10-10 00:00:00	2023-10-10 00:00:00	2023-11-10 00:00:00	1500000.00	t	2023-10-10 00:00:00	2
107	39265d84-df44-462e-a796-0c342281011d	6	4	2023-09-20 00:00:00	2023-09-20 00:00:00	2023-12-20 00:00:00	4200000.00	t	2023-09-20 00:00:00	2
108	4b8e045b-f717-4d8b-976c-e990e4722124	18	4	2024-07-25 00:00:00	2024-07-25 00:00:00	2024-09-25 00:00:00	2800000.00	t	2024-07-25 00:00:00	2
109	cf684dbf-0c4f-40d2-847b-88e7a9968f14	26	4	2023-06-17 00:00:00	2023-06-17 00:00:00	2023-08-17 00:00:00	3000000.00	t	2023-06-17 00:00:00	2
110	df99c4f1-0985-41e8-825a-964adef28e0c	24	4	2023-04-10 00:00:00	2023-04-10 00:00:00	2023-07-10 00:00:00	8500000.00	t	2023-04-10 00:00:00	2
111	2c9ff35f-8ec2-498b-8c02-87b272a2afec	25	4	2023-10-15 00:00:00	2023-10-15 00:00:00	2023-11-15 00:00:00	1700000.00	t	2023-10-15 00:00:00	2
112	869962c9-f404-4913-abdc-d998e5537163	26	4	2023-11-05 00:00:00	2023-11-05 00:00:00	2024-02-05 00:00:00	3000000.00	t	2023-11-05 00:00:00	2
113	df559399-613f-4562-83eb-87b12b0a0e78	24	4	2024-02-12 00:00:00	2024-02-12 00:00:00	2024-05-12 00:00:00	8500000.00	t	2024-02-12 00:00:00	2
114	a0941fb1-2df1-4b33-85a1-87abf012d7dd	1	4	2023-12-30 00:00:00	2023-12-30 00:00:00	2024-01-30 00:00:00	500000.00	t	2023-12-30 00:00:00	2
115	0bd283e0-c088-4eef-9c16-1a44c92cdf57	2	4	2023-10-03 00:00:00	2023-10-03 00:00:00	2023-11-03 00:00:00	1800000.00	t	2023-10-03 00:00:00	2
116	0bd283e0-c088-4eef-9c16-1a44c92cdf57	27	4	2024-02-20 00:00:00	2024-02-20 00:00:00	2024-05-20 00:00:00	5000000.00	t	2024-02-20 00:00:00	2
72	e0e147ab-7fce-4859-b208-2d552210ec2b	7	4	2023-01-15 00:00:00	2023-01-15 00:00:00	2023-02-15 00:00:00	600000.00	t	2023-01-15 00:00:00	2
73	e41c8b65-9629-44f9-8b9a-5e61323aacd7	8	4	2023-02-20 00:00:00	2023-02-20 00:00:00	2023-03-20 00:00:00	2200000.00	t	2023-02-20 00:00:00	2
74	3bba9fd6-c07b-450f-a8e4-4adccb032270	9	4	2023-03-10 00:00:00	2023-03-10 00:00:00	2023-06-10 00:00:00	6500000.00	t	2023-03-10 00:00:00	2
75	420b1d72-cc7b-4904-aca5-2ef0aba30d11	10	4	2023-04-05 00:00:00	2023-04-05 00:00:00	2023-05-05 00:00:00	500000.00	t	2023-04-05 00:00:00	2
76	816ebdf9-b63e-452a-84ff-ab6e522fe269	14	4	2023-05-10 00:00:00	2023-05-10 00:00:00	2023-07-10 00:00:00	4000000.00	t	2023-05-10 00:00:00	2
77	bc6d9d67-81a5-4e2b-a67a-e62e2bfa56c7	12	4	2023-06-12 00:00:00	2023-06-12 00:00:00	2023-07-12 00:00:00	1200000.00	t	2023-06-12 00:00:00	2
78	c16902d4-ccb8-4244-adc5-2e5233d8d13c	13	4	2023-07-15 00:00:00	2023-07-15 00:00:00	2023-08-15 00:00:00	2500000.00	t	2023-07-15 00:00:00	2
79	aa37dae0-4956-4307-951f-524d2253298b	15	4	2023-08-20 00:00:00	2023-08-20 00:00:00	2023-11-20 00:00:00	7500000.00	t	2023-08-20 00:00:00	2
80	de0928ea-f417-4dec-a607-a49b566fcb21	16	4	2023-09-01 00:00:00	2023-09-01 00:00:00	2023-12-01 00:00:00	12000000.00	t	2023-09-01 00:00:00	2
81	71e2d214-0f05-4ab7-9131-a157553e68a9	1	4	2023-10-10 00:00:00	2023-10-10 00:00:00	2023-11-10 00:00:00	500000.00	t	2023-10-10 00:00:00	2
82	1e278106-5053-4432-8a1d-547885f9c93a	2	4	2023-11-05 00:00:00	2023-11-05 00:00:00	2023-12-05 00:00:00	1800000.00	t	2023-11-05 00:00:00	2
83	68a00be2-5819-46ad-b12e-bf3d832458e6	3	4	2023-12-01 00:00:00	2023-12-01 00:00:00	2024-03-01 00:00:00	5000000.00	t	2023-12-01 00:00:00	2
84	1bda526c-b5bc-4968-927a-4f0bc809ab1e	4	4	2024-01-15 00:00:00	2024-01-15 00:00:00	2024-02-15 00:00:00	400000.00	t	2024-01-15 00:00:00	2
85	39265d84-df44-462e-a796-0c342281011d	5	4	2024-02-20 00:00:00	2024-02-20 00:00:00	2024-03-20 00:00:00	1500000.00	t	2024-02-20 00:00:00	2
86	4b8e045b-f717-4d8b-976c-e990e4722124	6	4	2024-03-10 00:00:00	2024-03-10 00:00:00	2024-06-10 00:00:00	4200000.00	t	2024-03-10 00:00:00	2
87	cf684dbf-0c4f-40d2-847b-88e7a9968f14	11	4	2024-04-01 00:00:00	2024-04-01 00:00:00	2024-10-01 00:00:00	1800000.00	t	2024-04-01 00:00:00	2
88	df99c4f1-0985-41e8-825a-964adef28e0c	17	4	2024-05-05 00:00:00	2024-05-05 00:00:00	2024-06-05 00:00:00	1500000.00	t	2024-05-05 00:00:00	2
89	2c9ff35f-8ec2-498b-8c02-87b272a2afec	18	4	2024-06-10 00:00:00	2024-06-10 00:00:00	2024-12-10 00:00:00	2800000.00	t	2024-06-10 00:00:00	2
90	869962c9-f404-4913-abdc-d998e5537163	20	4	2024-07-01 00:00:00	2024-07-01 00:00:00	2024-10-01 00:00:00	3500000.00	t	2024-07-01 00:00:00	2
91	df559399-613f-4562-83eb-87b12b0a0e78	19	4	2024-08-15 00:00:00	2024-08-15 00:00:00	2024-09-15 00:00:00	1200000.00	t	2024-08-15 00:00:00	2
92	a0941fb1-2df1-4b33-85a1-87abf012d7dd	21	4	2024-09-10 00:00:00	2024-09-10 00:00:00	2024-10-10 00:00:00	3000000.00	t	2024-09-10 00:00:00	2
93	0bd283e0-c088-4eef-9c16-1a44c92cdf57	22	4	2024-10-05 00:00:00	2024-10-05 00:00:00	2024-04-05 00:00:00	7000000.00	t	2024-10-05 00:00:00	2
\.


--
-- TOC entry 4912 (class 0 OID 27207)
-- Dependencies: 236
-- Data for Name: Appointments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Appointments" ("Id", "SubscriptionId", "AppointmentDate", "ShiftId", "Status", "StaffId", "Address", "Phone", "Note") FROM stdin;
3	95	2024-11-22 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
4	96	2024-11-25 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
62	88	2024-11-02 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
63	91	2024-11-04 09:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
64	110	2024-11-06 10:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
65	113	2024-11-09 11:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
66	111	2024-11-12 12:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
67	109	2024-11-14 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
68	112	2024-11-17 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
69	116	2024-11-20 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
70	88	2024-11-02 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
71	91	2024-11-04 09:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
72	110	2024-11-06 10:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
73	113	2024-11-09 11:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
74	111	2024-11-12 12:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
75	109	2024-11-14 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
76	112	2024-11-17 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
77	116	2024-11-20 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
78	88	2024-11-02 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
79	91	2024-11-04 09:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
80	110	2024-11-06 10:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
81	113	2024-11-09 11:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
82	111	2024-11-12 12:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
83	109	2024-11-14 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
84	112	2024-11-17 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
85	116	2024-11-20 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
86	88	2024-11-02 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
87	91	2024-11-04 09:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
88	92	2024-11-06 10:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
89	92	2024-11-09 11:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
90	92	2024-11-12 12:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
91	92	2024-11-14 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
92	92	2024-11-17 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
93	92	2024-11-20 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
44	101	2024-11-08 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
2	94	2024-11-09 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
5	105	2024-11-15 23:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
6	114	2024-11-15 18:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
7	81	2024-11-19 12:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
8	94	2024-11-15 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
9	95	2024-11-11 23:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
10	96	2024-11-09 16:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
11	105	2024-11-01 17:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
12	114	2024-11-23 09:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
13	81	2024-11-11 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
14	94	2024-11-03 21:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
15	95	2024-11-22 19:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
16	96	2024-11-06 22:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
17	105	2024-11-26 08:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
18	114	2024-11-28 11:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
19	81	2024-11-24 22:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
20	84	2024-11-28 11:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
21	84	2024-11-28 20:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
22	84	2024-11-13 12:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
23	84	2024-11-05 12:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
24	84	2024-11-01 12:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
25	81	2024-11-27 10:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
26	72	2024-11-29 12:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
27	72	2024-11-07 20:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
28	72	2024-11-05 21:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
29	72	2024-11-15 19:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
30	72	2024-11-08 11:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
31	72	2024-11-15 15:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
32	75	2024-11-16 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
33	75	2024-11-05 17:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
34	75	2024-11-18 09:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
35	75	2024-11-10 18:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
36	75	2024-11-11 22:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
37	75	2024-11-17 10:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
38	101	2024-11-27 18:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
39	77	2024-11-01 15:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
40	101	2024-11-05 13:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
41	77	2024-11-27 23:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
42	101	2024-11-24 11:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
43	77	2024-11-08 09:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
45	77	2024-11-09 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
46	101	2024-11-21 21:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
47	77	2024-11-21 17:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
48	101	2024-11-12 17:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
49	77	2024-11-12 18:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
50	101	2024-11-10 13:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
51	77	2024-11-13 17:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
52	101	2024-11-07 22:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
53	77	2024-11-19 19:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
54	101	2024-11-24 22:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
55	77	2024-11-23 08:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
56	101	2024-11-29 15:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
57	77	2024-11-12 08:00:00	2	2	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
58	101	2024-11-02 13:00:00	3	2	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
59	77	2024-11-11 18:00:00	4	2	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
60	101	2024-11-18 19:00:00	5	2	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
61	77	2024-11-14 14:00:00	1	2	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
94	88	2024-11-02 08:00:00	1	3	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
95	91	2024-11-04 09:00:00	2	3	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
96	110	2024-11-06 10:00:00	3	3	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
97	113	2024-11-09 11:00:00	4	3	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
98	111	2024-11-12 12:00:00	5	3	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
99	109	2024-11-14 13:00:00	1	3	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
100	112	2024-11-17 08:00:00	2	3	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
101	116	2024-11-20 09:00:00	3	3	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
102	88	2024-11-02 08:00:00	1	0	5af086da-71c5-4e86-a2a9-3f4ef5480946	123 Đường Lê Lợi, TP.HCM	0901234567	Lịch hẹn kiểm tra sức khỏe tổng quát
103	91	2024-11-04 09:00:00	2	0	bc69491a-856b-4254-82cf-a025bf87aaca	456 Đường Nguyễn Huệ, TP.HCM	0902345678	Khám vi chất cho trẻ em
104	110	2024-11-06 10:00:00	3	0	524265b7-fd64-48b1-abc6-3845aee24892	789 Đường Phạm Văn Đồng, TP.HCM	0903456789	Tư vấn xét nghiệm da liễu
105	113	2024-11-09 11:00:00	4	0	6bf214e6-070d-465c-93cf-3dc95200b96f	101 Đường Cộng Hòa, TP.HCM	0904567890	Khám và kiểm tra sức khỏe định kỳ
106	111	2024-11-12 12:00:00	5	0	4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	202 Đường Trần Phú, TP.HCM	0905678901	Tư vấn về chăm sóc người bệnh không lây nhiễm
107	109	2024-11-14 13:00:00	1	0	5af086da-71c5-4e86-a2a9-3f4ef5480946	303 Đường Võ Thị Sáu, TP.HCM	0906789012	Khám sức khỏe cho người lớn tuổi
108	112	2024-11-17 08:00:00	2	0	bc69491a-856b-4254-82cf-a025bf87aaca	789 Đường Phạm Văn Đồng, TP.HCM	0907890123	Tư vấn về tầm soát ung thư
109	116	2024-11-20 09:00:00	3	0	524265b7-fd64-48b1-abc6-3845aee24892	456 Đường Nguyễn Huệ, TP.HCM	0908901234	Khám và kiểm tra sức khỏe tổng quát
\.


--
-- TOC entry 4914 (class 0 OID 27230)
-- Dependencies: 238
-- Data for Name: AppointmentDetails; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AppointmentDetails" ("Id", "AppointmentId", "PatientCondition", "TreatmentProvided", "Notes", "NextAppointmentDate", "CreatedDate", "UpdatedDate") FROM stdin;
46	3	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-22 08:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
47	4	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-25 09:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
48	62	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-02 08:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
49	63	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-04 09:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
50	64	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-06 10:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
51	65	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-09 11:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
52	66	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-12 12:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
53	67	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-14 13:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
54	68	Tư vấn tầm soát ung thư	Tư vấn tầm soát ung thư	Tư vấn về tầm soát ung thư	2024-11-17 08:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
55	69	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	2024-11-20 09:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
56	70	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-02 08:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
57	71	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-04 09:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
58	72	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-06 10:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
59	73	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-09 11:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
60	74	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-12 12:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
61	75	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-14 13:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
62	76	Tư vấn tầm soát ung thư	Tư vấn tầm soát ung thư	Tư vấn về tầm soát ung thư	2024-11-17 08:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
63	77	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	2024-11-20 09:00:00	2024-11-07 09:13:11.029519	2024-11-07 09:13:11.029519
64	78	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-02 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
65	79	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-04 09:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
66	80	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-06 10:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
67	81	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-09 11:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
68	82	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-12 12:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
69	83	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-14 13:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
70	84	Tư vấn tầm soát ung thư	Tư vấn tầm soát ung thư	Tư vấn về tầm soát ung thư	2024-11-17 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
71	85	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	2024-11-20 09:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
72	86	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-02 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
73	87	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-04 09:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
74	88	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-06 10:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
75	89	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-09 11:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
76	90	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-12 12:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
77	91	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-14 13:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
78	92	Tư vấn tầm soát ung thư	Tư vấn tầm soát ung thư	Tư vấn về tầm soát ung thư	2024-11-17 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
79	93	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	Khám và kiểm tra sức khỏe tổng quát	2024-11-20 09:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
80	44	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-08 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
81	2	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-09 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
82	5	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-15 23:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
83	6	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-15 18:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
84	7	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-19 12:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
85	8	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-15 08:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
86	9	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-11 23:00:00	2024-11-07 09:13:52.047437	2024-11-07 09:13:52.047437
87	10	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-09 16:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
88	11	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-01 17:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
89	12	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-23 09:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
90	13	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-11 13:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
91	14	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-03 21:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
92	15	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-22 19:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
93	16	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-06 22:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
94	17	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-26 08:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
95	18	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-28 11:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
96	19	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-24 22:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
97	20	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-28 11:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
98	21	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-28 20:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
99	22	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-13 12:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
100	23	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-05 12:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
101	24	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-01 12:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
102	25	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-27 10:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
103	26	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-29 12:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
104	27	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-07 20:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
105	28	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-05 21:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
106	29	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-15 19:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
107	30	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-08 11:00:00	2024-11-07 09:14:34.152515	2024-11-07 09:14:34.152515
108	31	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-15 15:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
109	32	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-16 13:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
110	33	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-05 17:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
111	34	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-18 09:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
112	35	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-10 18:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
113	36	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-11 22:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
114	37	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-17 10:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
115	38	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-27 18:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
116	39	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-01 15:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
117	40	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-05 13:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
118	41	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-27 23:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
119	42	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-24 11:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
120	43	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-08 09:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
121	45	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-09 08:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
122	46	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-21 21:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
123	47	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-21 17:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
124	48	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-12 17:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
125	49	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-12 18:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
126	50	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-10 13:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
127	51	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-13 17:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
128	52	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-07 22:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
129	53	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-19 19:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
130	54	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-24 22:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
131	55	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-23 08:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
132	56	Kiểm tra sức khỏe tổng quát	Khám tổng quát	Lịch hẹn kiểm tra sức khỏe tổng quát	2024-11-29 15:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
133	57	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	Khám vi chất cho trẻ em	2024-11-12 08:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
134	58	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	Tư vấn xét nghiệm da liễu	2024-11-02 13:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
135	59	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	Khám và kiểm tra sức khỏe định kỳ	2024-11-11 18:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
136	60	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn chăm sóc người bệnh không lây nhiễm	Tư vấn về chăm sóc người bệnh không lây nhiễm	2024-11-18 19:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
137	61	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	Khám sức khỏe cho người lớn tuổi	2024-11-14 14:00:00	2024-11-07 09:15:11.719853	2024-11-07 09:15:11.719853
\.


--
-- TOC entry 4916 (class 0 OID 27245)
-- Dependencies: 240
-- Data for Name: AppointmentReviews; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AppointmentReviews" ("Id", "AppointmentId", "AppointmentRating", "AppointmentComment", "StaffRating", "StaffComment", "ReviewDate") FROM stdin;
2	3	5	Khám vi chất cho trẻ em	4	Tốt	2024-11-22 08:00:00
3	4	4	Tư vấn xét nghiệm da liễu	3	Hơi chậm	2024-11-25 09:00:00
4	62	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-02 08:00:00
5	63	4	Khám vi chất cho trẻ em	5	Tốt	2024-11-04 09:00:00
6	64	3	Tư vấn xét nghiệm da liễu	4	Hài lòng	2024-11-06 10:00:00
7	65	5	Khám và kiểm tra sức khỏe định kỳ	4	Rất tốt	2024-11-09 11:00:00
8	66	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	5	Chăm sóc tốt	2024-11-12 12:00:00
9	67	5	Khám sức khỏe cho người lớn tuổi	5	Chăm sóc tốt	2024-11-14 13:00:00
10	68	5	Tư vấn về tầm soát ung thư	5	Tốt	2024-11-17 08:00:00
11	69	4	Khám và kiểm tra sức khỏe tổng quát	4	Tốt	2024-11-20 09:00:00
12	70	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-02 08:00:00
13	71	4	Khám vi chất cho trẻ em	3	Hài lòng	2024-11-04 09:00:00
14	72	5	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-06 10:00:00
15	73	5	Khám và kiểm tra sức khỏe định kỳ	5	Chăm sóc tốt	2024-11-09 11:00:00
16	74	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Rất tốt	2024-11-12 12:00:00
17	75	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-14 13:00:00
18	76	5	Tư vấn về tầm soát ung thư	4	Chăm sóc tốt	2024-11-17 08:00:00
19	77	4	Khám và kiểm tra sức khỏe tổng quát	3	Hài lòng	2024-11-20 09:00:00
20	78	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-02 08:00:00
21	79	3	Khám vi chất cho trẻ em	3	Hài lòng	2024-11-04 09:00:00
22	80	4	Tư vấn xét nghiệm da liễu	5	Tốt	2024-11-06 10:00:00
23	81	4	Khám và kiểm tra sức khỏe định kỳ	4	Hài lòng	2024-11-09 11:00:00
24	82	5	Tư vấn về chăm sóc người bệnh không lây nhiễm	5	Tốt	2024-11-12 12:00:00
25	83	4	Khám sức khỏe cho người lớn tuổi	4	Tốt	2024-11-14 13:00:00
26	84	5	Tư vấn về tầm soát ung thư	5	Rất tốt	2024-11-17 08:00:00
27	85	5	Khám và kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-20 09:00:00
28	86	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-02 08:00:00
29	87	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-04 09:00:00
30	88	4	Tư vấn xét nghiệm da liễu	3	Hài lòng	2024-11-06 10:00:00
31	89	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-09 11:00:00
32	90	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-12 12:00:00
33	91	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-14 13:00:00
34	92	4	Tư vấn về tầm soát ung thư	4	Tốt	2024-11-17 08:00:00
35	93	5	Khám và kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-20 09:00:00
36	44	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-08 08:00:00
37	2	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-09 08:00:00
38	5	4	Khám và kiểm tra sức khỏe định kỳ	3	Hài lòng	2024-11-15 23:00:00
39	6	5	Tư vấn về chăm sóc người bệnh không lây nhiễm	5	Tốt	2024-11-15 18:00:00
40	7	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-19 12:00:00
41	8	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-15 08:00:00
42	9	4	Khám vi chất cho trẻ em	3	Hài lòng	2024-11-11 23:00:00
43	10	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-09 16:00:00
44	11	5	Khám và kiểm tra sức khỏe định kỳ	5	Chăm sóc tốt	2024-11-01 17:00:00
45	12	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-23 09:00:00
46	13	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-11 13:00:00
47	14	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-03 21:00:00
48	15	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-22 19:00:00
49	16	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-06 22:00:00
50	17	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-26 08:00:00
51	18	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-28 11:00:00
52	19	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-24 22:00:00
53	20	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-28 11:00:00
54	21	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-28 20:00:00
55	22	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-13 12:00:00
56	23	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-05 12:00:00
57	24	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-01 12:00:00
58	25	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-27 10:00:00
59	26	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-29 12:00:00
60	27	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-07 20:00:00
61	28	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-05 21:00:00
62	29	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-15 19:00:00
63	30	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-08 11:00:00
64	31	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-15 15:00:00
65	32	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-16 13:00:00
66	33	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-05 17:00:00
67	34	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-18 09:00:00
68	35	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-10 18:00:00
69	36	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-11 22:00:00
70	37	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-17 10:00:00
71	38	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-27 18:00:00
72	39	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-01 15:00:00
73	40	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-05 13:00:00
74	41	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-27 23:00:00
75	42	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-24 11:00:00
76	43	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-08 09:00:00
77	45	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-09 08:00:00
78	46	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-21 21:00:00
79	47	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-21 17:00:00
80	48	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-12 17:00:00
81	49	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-12 18:00:00
82	50	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-10 13:00:00
83	51	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-13 17:00:00
84	52	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-07 22:00:00
85	53	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-19 19:00:00
86	54	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-24 22:00:00
87	55	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-23 08:00:00
88	56	5	Lịch hẹn kiểm tra sức khỏe tổng quát	5	Rất tốt	2024-11-29 15:00:00
89	57	4	Khám vi chất cho trẻ em	4	Tốt	2024-11-12 08:00:00
90	58	4	Tư vấn xét nghiệm da liễu	4	Tốt	2024-11-02 13:00:00
91	59	5	Khám và kiểm tra sức khỏe định kỳ	5	Rất tốt	2024-11-11 18:00:00
92	60	4	Tư vấn về chăm sóc người bệnh không lây nhiễm	4	Tốt	2024-11-18 19:00:00
93	61	5	Khám sức khỏe cho người lớn tuổi	5	Rất tốt	2024-11-14 14:00:00
\.


--
-- TOC entry 4892 (class 0 OID 27067)
-- Dependencies: 216
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
1	Admin	ADMIN	\N
2	Staff	STAFF	\N
3	Patient	PATIENT	\N
\.


--
-- TOC entry 4901 (class 0 OID 27108)
-- Dependencies: 225
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- TOC entry 4903 (class 0 OID 27121)
-- Dependencies: 227
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- TOC entry 4904 (class 0 OID 27133)
-- Dependencies: 228
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
\.


--
-- TOC entry 4905 (class 0 OID 27145)
-- Dependencies: 229
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
e0e147ab-7fce-4859-b208-2d552210ec2b	3
e41c8b65-9629-44f9-8b9a-5e61323aacd7	3
3bba9fd6-c07b-450f-a8e4-4adccb032270	3
420b1d72-cc7b-4904-aca5-2ef0aba30d11	3
816ebdf9-b63e-452a-84ff-ab6e522fe269	3
bc6d9d67-81a5-4e2b-a67a-e62e2bfa56c7	3
c16902d4-ccb8-4244-adc5-2e5233d8d13c	3
aa37dae0-4956-4307-951f-524d2253298b	3
de0928ea-f417-4dec-a607-a49b566fcb21	3
71e2d214-0f05-4ab7-9131-a157553e68a9	3
1e278106-5053-4432-8a1d-547885f9c93a	3
68a00be2-5819-46ad-b12e-bf3d832458e6	3
1bda526c-b5bc-4968-927a-4f0bc809ab1e	3
39265d84-df44-462e-a796-0c342281011d	3
4b8e045b-f717-4d8b-976c-e990e4722124	3
cf684dbf-0c4f-40d2-847b-88e7a9968f14	3
df99c4f1-0985-41e8-825a-964adef28e0c	3
2c9ff35f-8ec2-498b-8c02-87b272a2afec	3
869962c9-f404-4913-abdc-d998e5537163	3
df559399-613f-4562-83eb-87b12b0a0e78	3
a0941fb1-2df1-4b33-85a1-87abf012d7dd	3
0bd283e0-c088-4eef-9c16-1a44c92cdf57	3
97f26527-9de3-4222-ae7d-ff85f99a273e	3
50af40f0-9df8-4b93-9f47-e2e57788cc54	3
e666a755-60b7-4574-b9f7-99acf40ca5be	3
98901cfa-cece-4af3-a25b-3d7b9e0c4753	3
3f56337a-18c6-4587-afd4-a3a43e3e7b2f	3
0b37603c-345c-4d08-a949-db19b28cb6ab	3
f30fc040-4089-4926-8647-8885123b65c1	3
16f724ae-c56f-4def-bce5-1d6138fc8b9a	3
69b80109-dcc0-4e3e-bf2c-402369dcf264	3
aabe2932-7b7a-4e09-906f-cd255b6ff07a	3
9824e4a5-0e48-4833-8117-02172fa85e95	3
7e953b92-971f-49ed-b023-dd2bd2ecdff4	3
f5c3af71-8fd7-416c-8469-2c81258054d4	3
75767b7f-a921-4d71-9f45-ded29835e81b	3
49adce5c-d393-4d56-beb4-800d6b9f4c4f	3
bcafe5f1-4ec3-4cb5-8de4-40e8a5d90e87	2
caf45385-b507-4376-88c3-a7fd513446c1	2
543a2abb-7ddf-4ef5-a757-5a6d7a538cb1	2
2c3f5257-1080-4f2b-83f6-9b81cc95e21b	2
5af086da-71c5-4e86-a2a9-3f4ef5480946	2
bc69491a-856b-4254-82cf-a025bf87aaca	2
524265b7-fd64-48b1-abc6-3845aee24892	2
6bf214e6-070d-465c-93cf-3dc95200b96f	2
4bbbf433-c5a6-4a51-870d-2c965ce6bc2c	2
af4018af-d3d1-4fed-a300-4da5dae2c298	2
12c58190-f166-4c7f-9201-e86e620e5707	2
5c19e7cd-e7fb-42d5-9851-d090679d94fb	2
394b8335-a0f4-4730-996f-4426c5806358	2
c4183601-41cc-429b-ae54-bc5057b91153	2
3d7ccf2e-e0f1-4363-8126-c1f477c6870a	2
6df68a87-bbf7-4ae9-acf6-a646c111e946	2
e3d5af7d-4f91-4419-8b98-585aeb01f88a	2
e58b2a65-4eb9-4f0c-8ffc-de335c3732ce	2
f4211892-2d33-48c6-9b93-04ab3fba15f2	1
2d0f2ee7-50ce-41b8-813d-8fa55c0cc2e0	3
\.


--
-- TOC entry 4906 (class 0 OID 27162)
-- Dependencies: 230
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
\.


--
-- TOC entry 4895 (class 0 OID 27084)
-- Dependencies: 219
-- Data for Name: Contacts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Contacts" ("Id", "PatientName", "PhoneNumber", "Service", "Message", "InquiryDate", "Status", "Note") FROM stdin;
1	Nguyễn An Nhiên	0123456789	Kiểm tra sức khỏe tổng quát	Tư vấn chọn gói kiểm tra tổng quát	2024-05-01 00:00:00	0	\N
2	Trần Hà Phương	0987654321	Xét nghiệm da liễu	Hỏi về quy trình và chi phí xét nghiệm da	2024-06-01 00:00:00	1	Đang chờ thêm thông tin
3	Lê Kiên Cường	0912345678	Vật lý trị liệu và phục hồi chức năng	Quan tâm đến vật lý trị liệu sau chấn thương	2024-07-01 00:00:00	0	\N
4	Phạm Tuấn Minh	0976543210	Chăm sóc người lớn tuổi	Hỏi về dịch vụ chăm sóc định kỳ	2024-08-01 00:00:00	1	Khách hàng yêu cầu tư vấn trực tiếp
5	Vũ Hồng Diễm	0934567890	Tầm soát ung thư toàn diện	Muốn tư vấn gói tầm soát ung thư	2024-09-01 00:00:00	0	\N
6	Đỗ Ngọc Lan	0901234567	Kiểm tra định kì viêm gan B	Yêu cầu kiểm tra viêm gan định kỳ	2024-10-01 00:00:00	1	Khách hàng quay lại
7	Bùi Phúc Lộc	0923456789	Chăm sóc sau phẫu thuật	Tư vấn dịch vụ chăm sóc hồi phục sau phẫu thuật	2024-11-01 00:00:00	0	\N
8	Hoàng Nguyên Đạt	0897654321	Xét nghiệm cơ xương khớp	Muốn biết chi phí xét nghiệm cơ xương khớp	2024-12-01 00:00:00	0	\N
9	Nguyễn Kim Tuyến	0845671234	Xét nghiệm tuyến giáp	Tư vấn gói xét nghiệm tuyến giáp	2024-01-13 00:00:00	1	Yêu cầu thêm về phương pháp xét nghiệm
10	Trần Bảo Anh	0834567891	Khám vi chất trẻ em	Quan tâm đến dịch vụ khám vi chất cho con	2024-01-14 00:00:00	0	\N
11	Lê Việt Hưng	0823456789	Chăm sóc người bệnh không lây nhiễm	Muốn đăng ký chăm sóc bệnh lâu dài	2024-01-15 00:00:00	1	Đã tư vấn chăm sóc dài hạn
12	Phạm Thanh Hòa	0812345678	Kiểm tra sức khỏe tổng quát	Hỏi về gói kiểm tra định kỳ	2024-01-16 00:00:00	0	\N
13	Vũ Minh Khánh	0801234567	Xét nghiệm thai lưu	Tư vấn quy trình xét nghiệm thai lưu	2024-01-17 00:00:00	1	Đang chờ xác nhận từ khách
14	Đỗ Quang Hải	0798765432	Tầm soát ung thư toàn diện	Quan tâm đến tầm soát định kỳ	2024-01-18 00:00:00	0	\N
15	Bùi Tú Anh	0787654321	Chăm sóc người lớn tuổi	Hỏi về chăm sóc người già tại nhà	2024-01-19 00:00:00	1	Khách hàng yêu cầu thêm thông tin
16	Hoàng Duy Linh	0776543210	Xét nghiệm da liễu	Tìm hiểu về xét nghiệm da	2024-01-20 00:00:00	0	\N
17	Nguyễn Tâm Đan	0765432109	Vật lý trị liệu và phục hồi chức năng	Tìm dịch vụ phục hồi chức năng	2024-01-21 00:00:00	1	Khách hàng cần phục hồi sau phẫu thuật
18	Trần Hữu Tâm	0754321098	Kiểm tra sức khỏe tổng quát	Quan tâm đến kiểm tra sức khỏe tổng quát	2024-01-22 00:00:00	0	\N
19	Lê Thắng	0743210987	Chăm sóc người bệnh không lây nhiễm	Tư vấn dịch vụ chăm sóc bệnh	2024-01-23 00:00:00	1	Đã nhận tư vấn
20	Phạm Văn Sơn	0732109876	Chăm sóc sau phẫu thuật	Muốn được hỗ trợ sau phẫu thuật	2024-01-24 00:00:00	0	\N
21	Vũ Như Quỳnh	0721098765	Kiểm tra định kì viêm gan B	Quan tâm đến xét nghiệm viêm gan	2024-01-25 00:00:00	1	Đã tư vấn dịch vụ định kỳ
22	Đỗ Chí Tâm	0710987654	Tầm soát ung thư toàn diện	Hỏi về các dịch vụ ung thư	2024-01-26 00:00:00	0	\N
23	Bùi Kim Chi	0709876543	Xét nghiệm tuyến giáp	Muốn tư vấn xét nghiệm tuyến giáp	2024-01-27 00:00:00	1	Đang chờ phản hồi
24	Hoàng Vĩnh Phú	0698765432	Khám vi chất trẻ em	Quan tâm đến khám vi chất cho trẻ	2024-01-28 00:00:00	0	\N
25	Nguyễn Xuân Hương	0687654321	Chăm sóc người lớn tuổi	Tư vấn chăm sóc người già	2024-01-29 00:00:00	1	Đã tư vấn gói dịch vụ
26	Trần Ngọc Quyên	0676543210	Kiểm tra sức khỏe tổng quát	Tìm dịch vụ kiểm tra sức khỏe	2024-01-30 00:00:00	0	\N
27	Lê Thái Vương	0665432109	Xét nghiệm da liễu	Tìm hiểu về quy trình xét nghiệm da	2024-01-31 00:00:00	1	Đã cung cấp thông tin
28	Phạm Khải Hoàn	0654321098	Vật lý trị liệu và phục hồi chức năng	Tư vấn vật lý trị liệu	2024-02-01 00:00:00	0	\N
29	Vũ Thùy Linh	0643210987	Kiểm tra định kì viêm gan B	Quan tâm đến gói kiểm tra định kỳ	2024-02-02 00:00:00	1	Đang chờ thêm thông tin
30	Đỗ Khánh Huy	0632109876	Chăm sóc người bệnh không lây nhiễm	Muốn đăng ký chăm sóc lâu dài	2024-02-03 00:00:00	0	\N
\.


--
-- TOC entry 4891 (class 0 OID 27062)
-- Dependencies: 215
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20241106082906_initial	8.0.8
\.


--
-- TOC entry 4922 (class 0 OID 0)
-- Dependencies: 237
-- Name: AppointmentDetails_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AppointmentDetails_Id_seq"', 137, true);


--
-- TOC entry 4923 (class 0 OID 0)
-- Dependencies: 239
-- Name: AppointmentReviews_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AppointmentReviews_Id_seq"', 93, true);


--
-- TOC entry 4924 (class 0 OID 0)
-- Dependencies: 235
-- Name: Appointments_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Appointments_Id_seq"', 109, true);


--
-- TOC entry 4925 (class 0 OID 0)
-- Dependencies: 224
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- TOC entry 4926 (class 0 OID 0)
-- Dependencies: 226
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


--
-- TOC entry 4927 (class 0 OID 0)
-- Dependencies: 218
-- Name: Contacts_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Contacts_Id_seq"', 1, false);


--
-- TOC entry 4928 (class 0 OID 0)
-- Dependencies: 231
-- Name: ServicePackages_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ServicePackages_Id_seq"', 27, true);


--
-- TOC entry 4929 (class 0 OID 0)
-- Dependencies: 220
-- Name: ServiceTypes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ServiceTypes_Id_seq"', 12, true);


--
-- TOC entry 4930 (class 0 OID 0)
-- Dependencies: 222
-- Name: Shifts_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Shifts_Id_seq"', 6, false);


--
-- TOC entry 4931 (class 0 OID 0)
-- Dependencies: 233
-- Name: Subscriptions_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Subscriptions_Id_seq"', 116, true);


-- Completed on 2024-11-07 09:49:18

--
-- PostgreSQL database dump complete
--

