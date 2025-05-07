

--gender types LookUpTable
CREATE TABLE dbo.GenderTypes(
	gender VARCHAR(50) PRIMARY KEY 
)
INSERT INTO dbo.GenderTypes(gender) VALUES ('Male'),('Female'),('Other')

--Employee Roles LookUpTable
CREATE TABLE dbo.EmployeeRoles(
	employeeRole VARCHAR(50) PRIMARY KEY
)
INSERT INTO dbo.EmployeeRoles(employeeRole) VALUES ('Teacher'),('Secretary'),('SchoolManager')

--Employee Statuses LookUpTable
CREATE TABLE dbo.EmployeeStatuses(
	employeeStatus VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.EmployeeStatuses(employeeStatus) VALUES ('Onboarding'),('SabbaticalYear'),('Temporary_Intership'),('PaternalLeave'),('Temporary_WaitingApproval'), ('Active'),('Retired'), ('Archived'),('Dismissal_WaitingForHearing'),('Dismissal_Dissmised'),('Dismissal_Appeal')


--Voucher Types LookUpTable
CREATE TABLE dbo.VoucherTypes(
	voucherType VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.VoucherTypes(voucherType) VALUES ('MandatoryPayment'),('ExternalActivity'),('WelfarePayment'),('SpecialTrack')

--question Types LookUpTable
CREATE TABLE dbo.QuestionTypes(
	questionType VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.QuestionTypes(questionType) VALUES ('MultipleChoice'),('TrueFalse'),('MultipleResponse')

--activity Types LookUpTable
CREATE TABLE dbo.ActivityTypes(
	activityType VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.ActivityTypes(activityType) VALUES ('Lecture'),('Show'),('Workshop'),('AnnualTrip')

--Resource Types LookUpTable
CREATE TABLE dbo.ResourceTypes(
	resourceType VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.ResourceTypes(resourceType) VALUES ('AnswerFile'),('AssignmentFile'),('StudentDoc'),('EmployeeDoc'),('LessonMedia')

--Resource Types LookUpTable
CREATE TABLE dbo.SubmissionBoxStatuses(
	submissionBoxStatus VARCHAR(100) PRIMARY KEY
)
INSERT INTO dbo.SubmissionBoxStatuses(submissionBoxStatus) VALUES ('OpenToSubmit'),('CloseToSubmit'),('CheckInProcess'),('Checked'),('Cancelled')



CREATE TABLE dbo.Classes(
	className VARCHAR(50) PRIMARY KEY
)

CREATE TABLE dbo.Subjects(
	subjectName VARCHAR(50) PRIMARY KEY
)



--Students Table
CREATE TABLE dbo.Students (
	id INTEGER PRIMARY KEY,
	firstName VARCHAR(50) ,
	lastName VARCHAR(50) ,
	gender VARCHAR(50) ,
	birthdate DATETIME ,
	phone VARCHAR(20) ,
	studentAddress VARCHAR(250) ,
	email VARCHAR(100) ,
	learningDifficulties TEXT,
	className VARCHAR(50)

	CONSTRAINT FK_genderS FOREIGN KEY(gender) REFERENCES dbo.GenderTypes (gender),
	CONSTRAINT FK_classS FOREIGN KEY(className) REFERENCES dbo.Classes (className) 
)

CREATE TABLE dbo.Employees (
	id INTEGER PRIMARY KEY,
	firstName VARCHAR(50) ,
	lastName VARCHAR(50) ,
	gender VARCHAR(50) ,
	birthdate DATETIME ,
	phone VARCHAR(20),
	employeeAddress VARCHAR(250) ,
	email VARCHAR(100) ,
	startWorkingDate DATETIME ,
	employeeStatus VARCHAR(100) ,
	employeeRole VARCHAR(50) 

	CONSTRAINT FK_genderE FOREIGN KEY(gender) REFERENCES dbo.GenderTypes (gender),
	CONSTRAINT FK_EmployeeStatus FOREIGN KEY(employeeStatus) REFERENCES dbo.EmployeeStatuses (employeeStatus),
	CONSTRAINT FK_EmployeeRole FOREIGN KEY(employeeRole) REFERENCES dbo.EmployeeRoles (employeeRole)
)

CREATE TABLE dbo.Assignments(
	assignmentId INTEGER PRIMARY KEY,
	assignmentName VARCHAR(100),
	creatingDate DATETIME,
	submissionDate DATETIME,
	assignmentDescription TEXT,
	employeeId INTEGER 

    CONSTRAINT FK_employeeIdA FOREIGN KEY (employeeId) REFERENCES dbo.Employees (id)


)




CREATE TABLE dbo.Vouchers(
	voucherId INTEGER PRIMARY KEY,
	voucherName VARCHAR(100),
	voucherType VARCHAR(100),
	dueDate DATETIME,
	cost FLOAT,
	producer INTEGER

	CONSTRAINT FK_voucherType FOREIGN KEY(voucherType) REFERENCES dbo.VoucherTypes (voucherType),
	CONSTRAINT FK_producer FOREIGN KEY (producer) REFERENCES dbo.Employees (id)
)


CREATE TABLE dbo.HomeroomTeachers(
	teacherId INTEGER,
	className VARCHAR(50)

	PRIMARY KEY (teacherId,className),
	CONSTRAINT FK_teacherId FOREIGN KEY (teacherId) REFERENCES dbo.Employees (id),
	CONSTRAINT FK_className FOREIGN KEY (className) REFERENCES dbo.Classes (className)
)



CREATE TABLE dbo.OnlineExams(
	examId VARCHAR(50) PRIMARY KEY,
	examName VARCHAR(100),
	startDate DATETIME,
	lastSubmissionDate DATETIME,
	creator INTEGER,
	examsubject VARCHAR(50)

	CONSTRAINT FK_creator FOREIGN KEY (creator) REFERENCES dbo.Employees (id),
	CONSTRAINT FK_examsubject FOREIGN KEY (examsubject) REFERENCES dbo.subjects (subjectName)
)

CREATE TABLE dbo.TestsToClass(
	examId VARCHAR(50),
	className VARCHAR(50)

	PRIMARY KEY (examId,className),
	CONSTRAINT FK_examId FOREIGN KEY (examId) REFERENCES dbo.OnlineExams (examId),
	CONSTRAINT FK_classNameTest FOREIGN KEY (className) REFERENCES dbo.Classes (className)
)

CREATE TABLE dbo.VouchersToStudents(
	studentId INTEGER,
	voucherId INTEGER 
	
	PRIMARY KEY(studentId,voucherId)

	CONSTRAINT FK_studentIdV FOREIGN KEY (studentId) REFERENCES dbo.Students (id),
	CONSTRAINT FK_voucherId FOREIGN KEY (voucherId) REFERENCES dbo.Vouchers (voucherId)
)

CREATE TABLE dbo.ExamQuestions(
	questionId VARCHAR(100) PRIMARY KEY,
	questionType VARCHAR(100),
	questionText VARCHAR(100),
	questionWeight FLOAT,
	examId VARCHAR(50)

	CONSTRAINT FK_examIdQ FOREIGN KEY (examId) REFERENCES dbo.OnlineExams (examId),
	CONSTRAINT FK_questionType FOREIGN KEY (questionType) REFERENCES dbo.QuestionTypes (questionType)
	
)

CREATE TABLE dbo.QuestionAnswers(
	answerId VARCHAR(100) PRIMARY KEY,
	isCorrect BIT,
	answerText VARCHAR(100),
	questionId VARCHAR(100)

	CONSTRAINT FK_questionId FOREIGN KEY (questionId) REFERENCES dbo.ExamQuestions (questionId)
)

CREATE TABLE dbo.ExternalActivities(
	activityId INTEGER PRIMARY KEY,
	startDate DATETIME,
	numOfParticipants INTEGER,
	cost FLOAT,
	activityType VARCHAR(100),
	endDateTime DATETIME,
 
 	CONSTRAINT FK_activityType FOREIGN KEY (activityType) REFERENCES dbo.ActivityTypes (activityType)
)

CREATE TABLE dbo.Participants(
	activityId INTEGER,
	studentId INTEGER

	PRIMARY KEY(activityId,studentId)

	CONSTRAINT FK_participnt_activity FOREIGN KEY(activityId) REFERENCES dbo.ExternalActivities(activityId),
	CONSTRAINT FK_participnt_student FOREIGN KEY(studentId) REFERENCES dbo.Students(id)

)


CREATE TABLE dbo.ConsentForms (
	dateOfSign DATETIME,
	healthIssues TEXT,
	activityId INTEGER,
	studentId INTEGER  

	PRIMARY KEY(activityId,studentId)

	CONSTRAINT FK_activityId FOREIGN KEY (activityId) REFERENCES dbo.ExternalActivities (activityId),
	CONSTRAINT FK_studentIdCF FOREIGN KEY (studentId) REFERENCES dbo.Students (id)
)


CREATE TABLE dbo.SubmissionBoxes(
	lastUpload DATETIME,
	studentId INTEGER,
	assignmentId INTEGER,
	submissionBoxStatus VARCHAR(100) 


	PRIMARY KEY(studentId,assignmentId)

	CONSTRAINT FK_studentIdS FOREIGN KEY (studentId) REFERENCES dbo.Students (id),
	CONSTRAINT FK_assignmentIdS FOREIGN KEY (assignmentId) REFERENCES dbo.Assignments (assignmentId),
	CONSTRAINT FK_submissionBoxStatus FOREIGN KEY (submissionBoxStatus) REFERENCES dbo.SubmissionBoxStatuses (submissionBoxStatus)


)

CREATE TABLE dbo.Resources(
	resourceUrl VARCHAR(100) PRIMARY KEY, 
	resourceType VARCHAR(100),
	resourceName VARCHAR(100),
	creatingDate DATETIME,
	lastUpdateDate DATETIME,
	studentId INTEGER ,
	employeeId INTEGER,
	assignmentId INTEGER,
	submissionAssignmentId INTEGER,  
	submissionStudentId INTEGER


	CONSTRAINT FK_studentIdR FOREIGN KEY (studentId) REFERENCES dbo.Students (id),
	CONSTRAINT FK_employeeIdR FOREIGN KEY (employeeId) REFERENCES dbo.Employees (id),
	CONSTRAINT FK_assignmentIdR FOREIGN KEY (assignmentId) REFERENCES dbo.Assignments (assignmentId),
	CONSTRAINT FK_submissionIdR FOREIGN KEY (submissionStudentId,submissionAssignmentId) REFERENCES dbo.SubmissionBoxes(studentId,assignmentId)
)


