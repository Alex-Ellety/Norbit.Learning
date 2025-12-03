SELECT
	p.name as 'Издательство'
	, COUNT(b.publisher_id) as 'Количество книг'
FROM book b
	INNER JOIN publisher p ON b.publisher_id = p.id
	INNER JOIN book_operation bo ON b.id = bo.book_id
WHERE bo.end_date is NULL
GROUP BY p.name
ORDER BY COUNT(b.publisher_id) desc