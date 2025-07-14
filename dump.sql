
CREATE DATABASE AcademyDB;
GO

USE AcademyDB;
GO

-- Cria a tabela Classes
CREATE TABLE classes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description TEXT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    DeletedAt DATETIME NULL
);
GO

-- Cria a tabela Students
CREATE TABLE students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    Cpf NVARCHAR(11) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    DeletedAt DATETIME NULL,

    CONSTRAINT UQ_students_Cpf UNIQUE (Cpf),
    CONSTRAINT UQ_students_Email UNIQUE (Email)
);
GO

-- Cria a tabela Enrollments
CREATE TABLE enrollments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    ClassId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    DeletedAt DATETIME NULL,

    CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentId)
        REFERENCES students(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_Enrollment_Class FOREIGN KEY (ClassId)
        REFERENCES classes(Id)
        ON DELETE CASCADE,

    CONSTRAINT UQ_Enrollment_Student_Class UNIQUE (StudentId, ClassId)
);
GO

-- Cria as constraints
CREATE INDEX IX_Enrollment_StudentId
    ON enrollments(StudentId);
GO

CREATE INDEX IX_Enrollment_ClassId
    ON enrollments(ClassId);
GO

-- Cria os registros fictícios
INSERT INTO students (Name, BirthDate, Cpf, Email, Password)
VALUES
('Ana Silva', '2000-04-10', '12345678900', 'ana.silva@email.com', 'hash_ana123'),
('Carlos Souza', '1998-09-23', '23456789011', 'carlos.souza@email.com', 'hash_carlos456'),
('Marina Costa', '2002-12-05', '34567890122', 'marina.costa@email.com', 'hash_marina789'),
('Felipe Moura', '1999-07-18', '45678901233', 'felipe.moura@email.com', 'hash_felipe321'),
('Juliana Rocha', '2001-02-28', '56789012344', 'juliana.rocha@email.com', 'hash_juliana654');

INSERT INTO classes (Name, Description)
VALUES
('Matemática Básica', 'Curso introdutório de matemática.'),
('Programação C#', 'Fundamentos da linguagem C# para iniciantes.'),
('História Geral', 'Panorama das principais civilizações antigas.'),
('Inglês Intermediário', 'Desenvolvimento de habilidades de leitura e conversação.'),
('Banco de Dados', 'Introdução a sistemas relacionais e SQL Server.');

INSERT INTO enrollments (StudentId, ClassId)
VALUES
(1, 2), 
(1, 5),
(2, 1),
(3, 4),
(4, 2);

