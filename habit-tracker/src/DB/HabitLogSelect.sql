-- SQLite
SELECT 
    hl.habitlogid,
    h.habitname, 
    hl.date, 
    hl.quantity 
FROM HabitLog hl
INNER JOIN Habit h on hl.habitid = h.habitid;