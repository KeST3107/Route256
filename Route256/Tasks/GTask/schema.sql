CREATE TABLE client
(
    "id"    int,
    "email" varchar(15)
)
;

INSERT INTO client
    ("id", "email")
VALUES (1, 'client1@ozon.ru'),
       (2, 'client2@ozon.ru'),
       (3, 'client3@ozon.ru'),
       (4, 'client4@ozon.ru'),
       (5, 'client5@ozon.ru'),
       (6, 'client6@ozon.ru')
;


CREATE TABLE "order"
(
    "id"         int,
    "client_id"  int,
    "created_at" timestamp,
    "updated_at" timestamp
)
;

INSERT INTO "order"
    ("id", "client_id", "created_at", "updated_at")
VALUES (1, 1, '2021-09-01 12:30:00', '2021-09-12 12:24:00'),
       (2, 1, '2021-08-02 12:30:00', '2021-09-12 12:24:00'),
       (3, 2, '2021-09-01 12:30:00', '2021-09-12 12:24:00'),
       (4, 2, '2021-10-04 12:30:00', '2021-09-12 12:24:00'),
       (5, 3, '2021-09-05 12:30:00', '2021-09-12 12:24:00'),
       (6, 3, '2021-11-06 12:30:00', '2021-09-12 12:24:00'),
       (7, 4, '2021-09-07 12:30:00', '2021-09-12 12:24:00'),
       (8, 4, '2021-11-08 12:30:00', '2021-09-12 12:24:00'),
       (9, 5, '2021-09-09 12:30:00', '2021-09-12 12:24:00'),
       (10, 5, '2021-09-10 12:30:00', '2021-09-12 12:24:00'),
       (11, 6, '2021-12-11 12:30:00', '2021-09-12 12:24:00'),
       (12, 6, '2021-09-12 12:30:00', '2021-09-12 12:24:00')
;


CREATE TABLE product
(
    "id"       int,
    "order_id" int,
    "cnt"      int,
    "price"    int
)
;

INSERT INTO product
    ("id", "order_id", "cnt", "price")
VALUES (1, 1, 2, 350),
       (2, 1, 1, 100),
       (3, 2, 1, 500),
       (4, 2, 1, 600),
       (5, 3, 1, 500),
       (6, 3, 2, 550),
       (7, 4, 4, 500),
       (8, 4, 5, 300),
       (9, 5, 1, 500),
       (10, 5, 1, 400),
       (11, 6, 1, 1500),
       (12, 6, 1, 1000),
       (13, 7, 2, 1000),
       (14, 7, 1, 100),
       (15, 8, 1, 500),
       (16, 8, 1, 600),
       (17, 9, 1, 100),
       (18, 9, 1, 550),
       (19, 10, 4, 500),
       (20, 10, 5, 300),
       (21, 11, 1, 1500),
       (22, 11, 1, 5000),
       (23, 12, 1, 100),
       (24, 12, 1, 5000)
;
