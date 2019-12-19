CREATE DATABASE Universidad
GO
USE Universidad
GO
CREATE TABLE Cursos
(
 Nombre_Curso NVARCHAR(20) NOT NULL,
 Materias nvarchar(50)NOT NULL,
 Alumnos nvarchar(50) NOT NULL
)

INSERT INTO Cursos(Nombre_Curso, Materias, Alumnos) VALUES('Math', 'Calculo, Pre calculo y Algebra','Arturo, Luis, Pepe' )