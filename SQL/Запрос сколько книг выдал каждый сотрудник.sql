SELECT
	e.name 'Имя сотрудника'
	, COUNT(bo.employee_id) 'Количество выданных книг'
FROM employee e
	INNER JOIN book_operation bo ON bo.employee_id = e.id
GROUP BY e.name