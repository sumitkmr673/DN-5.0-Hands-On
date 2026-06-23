WITH DateCTE AS (
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    SELECT DATEADD(day, 1, CalendarDate)
    FROM DateCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT CalendarDate 
FROM DateCTE;