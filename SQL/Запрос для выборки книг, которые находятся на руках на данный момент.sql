SELECT
	b.title 'Название'
	, a.name as 'Автор'
	, bo.end_date
FROM book_operation bo
	INNER JOIN book b ON b.id = bo.book_id
	INNER JOIN author a ON a.id = b.author_id
WHERE bo.end_date IS NULL