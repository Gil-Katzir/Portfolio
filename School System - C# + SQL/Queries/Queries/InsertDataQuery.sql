
-- Add entries to dbo.Classes
INSERT INTO dbo.Classes (className) VALUES 
('ClassA'), ('ClassB'), ('ClassC'), ('ClassD'), ('ClassE');

-- Add entries to dbo.Subjects
INSERT INTO dbo.Subjects (subjectName) VALUES 
('Math'), ('Science'), ('History'), ('English'), ('Art');

-- Add entries to dbo.Students
INSERT INTO dbo.Students (id, firstName, lastName, gender, birthdate, phone, studentAddress, email, learningDifficulties, className) VALUES
(1, 'Alice', 'Smith', 'Female', '2005-01-01', '1234567890', '123 Elm St', 'alice.smith@mail.com', NULL, 'ClassA'),
(2, 'Bob', 'Jones', 'Male', '2004-05-15', '9876543210', '456 Oak St', 'bob.jones@mail.com', 'Dyslexia', 'ClassB'),
(3, 'Charlie', 'Brown', 'Male', '2006-09-20', '5555555555', '789 Pine St', 'charlie.brown@mail.com', NULL, 'ClassC'),
(4, 'Diana', 'Ross', 'Female', '2005-07-30', '4444444444', '101 Maple St', 'diana.ross@mail.com', 'ADHD', 'ClassD'),
(5, 'Eve', 'Adams', 'Other', '2006-12-10', '3333333333', '202 Birch St', 'eve.adams@mail.com', NULL, 'ClassE');

-- Add entries to dbo.Employees
INSERT INTO dbo.Employees (id, firstName, lastName, gender, birthdate, phone, employeeAddress, email, startWorkingDate, employeeStatus, employeeRole) VALUES
(1, 'John', 'Doe', 'Male', '1980-04-20', '1111111111', '1 Infinite Loop', 'john.doe@mail.com', '2020-01-01', 'Active', 'Teacher'),
(2, 'Jane', 'Smith', 'Female', '1985-03-15', '2222222222', '2 Apple St', 'jane.smith@mail.com', '2018-06-15', 'Onboarding', 'Secretary'),
(3, 'Bill', 'Gates', 'Male', '1975-10-28', '6666666666', '3 Microsoft Way', 'bill.gates@mail.com', '2015-09-10', 'Active', 'SchoolManager'),
(4, 'Elon', 'Musk', 'Male', '1971-06-28', '7777777777', '4 SpaceX Rd', 'elon.musk@mail.com', '2019-11-20', 'Active', 'Teacher'),
(5, 'Marie', 'Curie', 'Female', '1988-11-07', '8888888888', '5 Nobel Blvd', 'marie.curie@mail.com', '2021-02-15', 'SabbaticalYear', 'Secretary');

-- Add entries to dbo.Assignments
INSERT INTO dbo.Assignments (assignmentId, assignmentName, creatingDate, submissionDate, assignmentDescription, employeeId) VALUES
(1, 'Math Assignment', '2024-01-01', '2025-02-01', 'Algebra problems', 1),
(2, 'Science Project', '2024-01-10', '2025-02-10', 'Physics experiment', 1),
(3, 'History Essay', '2024-01-15', '2025-02-15', 'World War II analysis', 4),
(4, 'English Test', '2024-01-20', '2024-02-20', 'Essay writing', 1),
(5, 'Art Portfolio', '2024-01-25', '2024-02-25', 'Painting submission', 4);

-- Add entries to dbo.Vouchers
INSERT INTO dbo.Vouchers (voucherId, voucherName, voucherType, dueDate, cost, producer) VALUES
(1, 'January Payment', 'MandatoryPayment', '2024-01-31', 100.0, 3),
(2, 'School Trip', 'ExternalActivity', '2024-02-15', 50.0, 4),
(3, 'Sports Equipment', 'WelfarePayment', '2024-03-01', 200.0, 2),
(4, 'Music Class', 'SpecialTrack', '2024-03-15', 150.0, 3),
(5, 'Drama Club', 'ExternalActivity', '2024-04-01', 75.0, 1);

-- Add entries to dbo.HomeroomTeachers
INSERT INTO dbo.HomeroomTeachers (teacherId, className) VALUES
(1, 'ClassA'), (4, 'ClassB'), (3, 'ClassC'), (2, 'ClassD'), (5, 'ClassE');

-- Add entries to dbo.OnlineExams
INSERT INTO dbo.OnlineExams (examId, examName, startDate, lastSubmissionDate, creator, examsubject) VALUES
('E1', 'Math Quiz', '2024-02-01', '2024-02-02', 1, 'Math'),
('E2', 'Science Test', '2024-02-10', '2024-02-11', 1, 'Science'),
('E3', 'History Quiz', '2024-02-20', '2024-02-21', 3, 'History'),
('E4', 'English Exam', '2024-03-01', '2024-03-02', 4, 'English'),
('E5', 'Art Showcase', '2024-03-10', '2024-03-11', 5, 'Art');

-- Add entries to dbo.TestsToClass
INSERT INTO dbo.TestsToClass (examId, className) VALUES
('E1', 'ClassA'), ('E2', 'ClassB'), ('E3', 'ClassC'), ('E4', 'ClassD'), ('E5', 'ClassE');

-- Add entries to dbo.VouchersToStudents
INSERT INTO dbo.VouchersToStudents (studentId, voucherId) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5);

-- Add entries to dbo.ExamQuestions
INSERT INTO dbo.ExamQuestions (questionId, questionType, questionText, questionWeight, examId) VALUES
('Q1', 'MultipleChoice', 'What is 2+2?', 1.0, 'E1'),
('Q2', 'TrueFalse', 'The Earth is flat.', 0.5, 'E2'),
('Q3', 'MultipleResponse', 'Select all world wars.', 2.0, 'E3'),
('Q4', 'MultipleChoice', 'Define irony.', 1.5, 'E4'),
('Q5', 'TrueFalse', 'Art is subjective.', 1.0, 'E5');

-- Add entries to dbo.QuestionAnswers
INSERT INTO dbo.QuestionAnswers (answerId, isCorrect, answerText, questionId) VALUES
('A1', 1, '4', 'Q1'), ('A2', 0, '5', 'Q1'),
('A3', 0, 'True', 'Q2'), ('A4', 1, 'False', 'Q2'),
('A5', 1, 'WWI', 'Q3'), ('A6', 1, 'WWII', 'Q3'),
('A7', 1, 'Opposite meanings', 'Q4'), ('A8', 0, 'Same meanings', 'Q4'),
('A9', 1, 'Yes', 'Q5'), ('A10', 0, 'No', 'Q5');

-- Add entries to dbo.ExternalActivities
INSERT INTO dbo.ExternalActivities (activityId, startDate, numOfParticipants, cost, activityType, endDateTime) VALUES
(1, '2024-02-01', 20, 500.0, 'Lecture', '2024-02-01 15:00'),
(2, '2024-02-05', 15, 300.0, 'Show', '2024-02-05 17:00'),
(3, '2024-02-10', 30, 1000.0, 'Workshop', '2024-02-10 18:00'),
(4, '2024-02-15', 25, 750.0, 'AnnualTrip', '2024-02-15 20:00'),
(5, '2024-02-20', 10, 200.0, 'Lecture', '2024-02-20 14:00');

-- Add entries to dbo.Participants
INSERT INTO dbo.Participants (activityId, studentId) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),(2, 1), (3, 1), (4, 1), (5, 1);



-- Add entries to dbo.ConsentForms
INSERT INTO dbo.ConsentForms (dateOfSign, healthIssues, activityId, studentId) VALUES
('2024-01-20', NULL, 1, 1),
('2024-01-21', 'Asthma', 2, 2),
('2024-01-22', NULL, 3, 3),
('2024-01-23', 'Allergy', 4, 4),
('2024-01-24', NULL, 5, 5);

-- Add entries to dbo.SubmissionBoxes
INSERT INTO dbo.SubmissionBoxes (lastUpload, studentId, assignmentId, submissionBoxStatus) VALUES
('2024-01-30', 1, 1, 'OpenToSubmit'),
('2024-01-30', 1, 2, 'OpenToSubmit'),
('2024-01-25', 1, 3, 'OpenToSubmit'),
('2024-01-31', 2, 2, 'OpenToSubmit'),
('2024-02-01', 3, 3, 'OpenToSubmit'),
('2024-02-02', 4, 4, 'Checked'),
('2024-02-03', 5, 5, 'CloseToSubmit');

-- Add entries to dbo.Resources
INSERT INTO dbo.Resources (resourceUrl, resourceType, resourceName, creatingDate, lastUpdateDate, studentId, employeeId, assignmentId, submissionAssignmentId, submissionStudentId) VALUES
('http://resource2/computer.pdf', 'AnswerFile', 'Math Solutions', '2024-01-01', '2024-01-02', null, null, null, 1, 1),
('http://resource3/computer.pdf', 'AssignmentFile', 'Science Data', '2024-01-03', '2024-01-04',null , null, 2, null, null),
('http://resource4/computer.pdf', 'StudentDoc', 'History Notes', '2024-01-05', '2024-01-06', 3, null, null, null, null),
('http://resource5/computer.pdf', 'EmployeeDoc', 'English Essay', '2024-01-07', '2024-01-08', null, 4, null, null, null),
('http://resource6/computer.pdf', 'AnswerFile', 'Art Slides', '2024-01-09', '2024-01-10', null, null, null, 2, 2);


