SELECT
	b.title 'Название'
	, COUNT(bo.book_id) as 'Количество запросов'
FROM book_operation bo
	INNER JOIN book b ON b.id = bo.book_id
GROUP BY b.title
ORDER BY COUNT(bo.book_id) DESC