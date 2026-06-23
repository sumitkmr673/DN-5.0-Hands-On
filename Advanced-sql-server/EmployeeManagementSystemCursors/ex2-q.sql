DECLARE cursor_static CURSOR STATIC FOR SELECT * FROM Employees;

DECLARE cursor_dynamic CURSOR DYNAMIC FOR SELECT * FROM Employees;

DECLARE cursor_forward CURSOR FORWARD_ONLY FOR SELECT * FROM Employees;

DECLARE cursor_keyset CURSOR KEYSET FOR SELECT * FROM Employees;

-- deallocate cursors
DEALLOCATE cursor_static;
DEALLOCATE cursor_dynamic;
DEALLOCATE cursor_forward;
DEALLOCATE cursor_keyset;
GO