SELECT client.id as id, AVG(product.price * product.cnt) as "avg_order"
FROM client
         INNER JOIN "order" ON client.id = "order".client_id
         INNER JOIN product ON product.order_id = "order".id
WHERE EXISTS(
              SELECT COUNT("order".id)
              FROM "order"
              WHERE EXISTS(
                            SELECT product.order_id
                            FROM product
                            GROUP BY product.order_id
                            HAVING "order".id = product.order_id
                               AND MIN(product.price) > 0
                               AND MIN(product.cnt) > 0
                               AND SUM(product.price * product.cnt) > 1000)
              GROUP BY "order".client_id
              HAVING "order".client_id = client.id
                 AND COUNT("order".id) >= 2)
GROUP BY client.id
ORDER BY client.id ASC
