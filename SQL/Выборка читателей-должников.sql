SELECT
	name 'Имя'
	, surname 'Фамилия'
FROM reader r
	INNER JOIN book_operation bo ON bo.reader_id = r.id
WHERE bo.end_date IS NULL
GROUP BY name, surname