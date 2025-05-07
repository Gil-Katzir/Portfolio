CREATE PROCEDURE dbo.SP_add_employee 
	@id INTEGER,
	@firstName VARCHAR(50) ,
	@lastName VARCHAR(50),
	@gender VARCHAR(50), 
	@birthdate DATETIME,
	@phone VARCHAR(20),
	@employeeAddress VARCHAR(250),
	@email VARCHAR(100), 
	@startWorkingDate DATETIME,
	@employeeStatus VARCHAR(100),
	@employeeRole VARCHAR(50)
AS
INSERT INTO dbo.Employees
Values (@id, @firstName, @lastName,@gender,@birthdate,@phone,@employeeAddress,@email,@startWorkingDate,@employeeStatus,@employeeRole)


CREATE PROCEDURE dbo.SP_add_student
	@id INTEGER,
	@firstName VARCHAR(50) ,
	@lastName VARCHAR(50),
	@gender VARCHAR(50), 
	@birthdate DATETIME,
	@phone VARCHAR(20),
	@studentAddress VARCHAR(250),
	@email VARCHAR(100), 
	@learningDifficulties TEXT
AS
INSERT INTO dbo.Students
Values (@id, @firstName, @lastName,@gender,@birthdate,@phone,@studentAddress,@email,@learningDifficulties)


CREATE PROCEDURE dbo.SP_add_resource
	@resourceUrl VARCHAR(100),
	@resourceType VARCHAR(100) ,
	@resourceName VARCHAR(100),
	@creatingDate DATETIME, 
	@lastUpdateDate DATETIME,
	@studentId INTEGER,
	@employeeId INTEGER,
	@assignmentId INTEGER, 
	@submissionAssignmentId INTEGER,
	@submissionStudentId INTEGER
AS
INSERT INTO dbo.Resources
Values (@resourceUrl, @resourceType, @resourceName,@creatingDate,@lastUpdateDate,@studentId,@employeeId,@assignmentId,@submissionAssignmentId,@submissionStudentId)



CREATE PROCEDURE dbo.SP_add_submission
	@studentId INTEGER,
	@assignmentId INTEGER ,
	@lastUpload DATETIME,
	@submissionStatus VARCHAR(100) 

AS
INSERT INTO dbo.SubmissionBoxes
Values (@lastUpload, @studentId, @assignmentId  ,@submissionStatus)










--כניראה כבר לא רלוונטית 
CREATE PROCEDURE dbo.SP_add_student_assignment
	@assignmentId INTEGER,
	@studentId INTEGER 
AS
INSERT INTO dbo.StudentAssignments
Values (@assignmentId, @studentId)


CREATE PROCEDURE dbo.SP_add_assignment
	@assignmentId INTEGER,
	@assignmentName VARCHAR(100) ,
	@creatingDate DATETIME,
	@submissionDate DATETIME, 
	@assignmentDescription TEXT,
	@employeeId INTEGER
	
AS
INSERT INTO dbo.Assignments
Values (@assignmentId, @assignmentName, @creatingDate,@submissionDate,@assignmentDescription,@employeeId)





CREATE PROCEDURE dbo.SP_add_consent_form
	@dateOfSign DATETIME,
	@healthIssues TEXT ,
	@activityId INTEGER,
	@studentId INTEGER	
AS
INSERT INTO dbo.ConsentForms
Values (@dateOfSign, @healthIssues, @activityId,@studentId)


CREATE PROCEDURE dbo.SP_get_all_employees
AS
Select*from dbo.Employees

CREATE PROCEDURE dbo.SP_get_all_assignments
AS
Select*from dbo.Assignments






CREATE PROCEDURE dbo.SP_get_all_external_activities
AS
Select*from dbo.ExternalActivities


CREATE PROCEDURE dbo.SP_get_all_vouchers
AS
Select*from dbo.Vouchers

CREATE PROCEDURE dbo.SP_get_all_vouchers_students
AS
Select*from dbo.VouchersToStudents



CREATE PROCEDURE dbo.SP_get_all_external_activities
AS
Select*from dbo.ExternalActivities


CREATE PROCEDURE dbo.SP_get_all_consent_forms
AS
Select*from dbo.ConsentForms



CREATE PROCEDURE dbo.SP_get_all_students
AS
Select*from dbo.Students

CREATE PROCEDURE dbo.SP_get_all_classes
AS
Select*from dbo.Classes


CREATE PROCEDURE dbo.SP_get_all_submissions
AS
Select*from dbo.SubmissionBoxes


CREATE PROCEDURE dbo.SP_get_all_resources
AS
Select*from dbo.Resources





CREATE PROCEDURE dbo.SP_get_employee @id VARCHAR(10)
AS
Select* from dbo.Employees where id=@id

CREATE PROCEDURE dbo.SP_get_student @id VARCHAR(10)
AS
Select* from dbo.Students where id=@id

CREATE PROCEDURE dbo.SP_update_employee 
	@id VARCHAR(10),
	@firstName VARCHAR(50) ,
	@lastName VARCHAR(50),
	@gender VARCHAR(50), 
	@birthdate DATETIME,
	@phone VARCHAR(20),
	@employeeAddress VARCHAR(250),
	@email VARCHAR(100), 
	@startWorkingDate DATETIME,
	@employeeStatus VARCHAR(100),
	@employeeRole VARCHAR(50)
AS
Update dbo.Employees
SET
	firstName=@firstName,
	lastName=@lastName,
	gender=@gender,
	birthdate=@birthdate,
	phone=@phone,
	employeeAddress=@employeeAddress,
	email=@email,
	startWorkingDate=@startWorkingDate,
	employeeStatus=@employeeStatus,
	employeeRole=@employeeRole
WHERE id=@id


CREATE PROCEDURE dbo.SP_update_student 
	@id VARCHAR(10),
	@firstName VARCHAR(50) ,
	@lastName VARCHAR(50),
	@gender VARCHAR(50), 
	@birthdate DATETIME,
	@phone VARCHAR(20),
	@studentAddress VARCHAR(250),
	@email VARCHAR(100), 
	@learningDifficulties TEXT
AS
Update dbo.Students
SET
	firstName=@firstName,
	lastName=@lastName,
	gender=@gender,
	birthdate=@birthdate,
	phone=@phone,
	studentAddress=@studentAddress,
	email=@email,
	learningDifficulties=@learningDifficulties
WHERE id=@id



CREATE PROCEDURE dbo.SP_update_resource_url 
	@oldUrl VARCHAR(100),
	@newUrl VARCHAR(100),
	@lastUpdateDate DATETIME

AS
Update dbo.Resources
SET
	resourceUrl=@newUrl,
	lastUpdateDate=@lastUpdateDate
WHERE resourceUrl=@oldUrl


CREATE PROCEDURE dbo.SP_update_last_submission_date
	@studentId INTEGER,
	@assignmentId INTEGER,
	@lastUpdateDate DATETIME

AS
Update dbo.SubmissionBoxes
SET
	lastUpload=@lastUpdateDate
WHERE studentId=@studentId AND assignmentId=@assignmentId








CREATE PROCEDURE dbo.SP_delete_employee @id VARCHAR(10)
AS
Delete from  dbo.Employees
WHERE id=@id

CREATE PROCEDURE dbo.SP_delete_student @id VARCHAR(10)
AS
Delete from  dbo.Students
WHERE id=@id



--הפקת שובר חדש לסטודנט אחד 
CREATE PROCEDURE dbo.SP_new_voucher_for_student
	@voucherId INTEGER,
    @studentId INTEGER,         
    @voucherName VARCHAR(100),     
    @voucherType VARCHAR(100),       
    @dueDate DATETIME,               
    @cost FLOAT,                    
    @producer VARCHAR(10)           
AS
    INSERT INTO dbo.Vouchers (voucherId, voucherName, voucherType, dueDate, cost, producer)
    VALUES (@VoucherId, @voucherName, @voucherType, @dueDate, @cost, @producer)

    INSERT INTO dbo.VouchersToStudents (studentId, voucherId)
    VALUES (@studentId, @VoucherId)



--קישור בין השובר לבין כל התלמידים
CREATE PROCEDURE dbo.SP_voucher_for_student
	@voucherId INTEGER,
    @studentId INTEGER                     
AS 
    -- הוספת קשר בין השובר החדש לסטודנט בטבלת VouchersToStudent
    INSERT INTO dbo.VouchersToStudents (studentId, voucherId)
    VALUES (@studentId, @VoucherId)




-- בדיקה ישירה אם יש קשר בין הסטודנט לשובר והחזרת התוצאה
CREATE PROCEDURE dbo.SP_check_student_voucher
    @studentId INTEGER,
    @voucherId INTEGER
AS
BEGIN
    SELECT CASE 
               WHEN EXISTS (SELECT 1 FROM dbo.VouchersToStudents WHERE studentId = @studentId AND voucherId = @voucherId)
               THEN 1
               ELSE 0 
           END AS IsLinked
END




 -- בדיקה ישירה אם יש אישור חתימה בין הסטודנט לפעילות והחזרת התוצאה
CREATE PROCEDURE dbo.SP_check_signed_student_activity
    @studentId INTEGER,
    @activityId INTEGER
AS
BEGIN
    SELECT CASE 
               WHEN EXISTS (SELECT 1 FROM dbo.ConsentForms WHERE studentId = @studentId AND activityId = @activityId)
               THEN 1
               ELSE 0 
           END AS IsLinked
END




CREATE PROCEDURE dbo.SP_check_invited_student_activity
    @studentId INTEGER,
    @activityId INTEGER
AS
BEGIN
    -- בדיקה ישירה אם יש קשר השתתפות בין הסטודנט לפעילות והחזרת התוצאה
    SELECT CASE 
               WHEN EXISTS (SELECT 1 FROM dbo.Participants WHERE studentId = @studentId AND activityId = @activityId)
               THEN 1
               ELSE 0 
           END AS IsLinked
END


--שיוך כיתה חדשה למורה 
CREATE PROCEDURE dbo.SP_class_for_teacher
	@employeeId INTEGER,
    @className INTEGER                     
AS 
	INSERT INTO dbo.HomeroomTeachers (teacherId, className)
    VALUES (@employeeId, @className)
         


--מחיקת עובד מהמערכת
CREATE PROCEDURE dbo.SP_delete_employee @id INTEGER
AS

		DELETE FROM dbo.QuestionAnswers 
		WHERE questionId IN (
        SELECT questionId 
        FROM dbo.ExamQuestions 
        WHERE examId IN (SELECT examId FROM dbo.OnlineExams WHERE creator = @id)
    )



		DELETE FROM dbo.ExamQuestions WHERE examId IN (SELECT examId FROM dbo.OnlineExams WHERE creator = @id);
		DELETE FROM dbo.VouchersToStudents WHERE voucherId IN (SELECT voucherId FROM dbo.Vouchers WHERE producer = @id);
        DELETE FROM dbo.TestsToClass WHERE examId IN (SELECT examId FROM dbo.OnlineExams WHERE creator = @id);

	    DELETE FROM dbo.Vouchers WHERE producer = @id;
        DELETE FROM dbo.Resources WHERE employeeId = @id;
        DELETE FROM dbo.HomeroomTeachers WHERE teacherId = @id;
        DELETE FROM dbo.OnlineExams WHERE creator = @id;
        DELETE FROM dbo.Employees WHERE id = @id;



--עדכון פרטי עובד 
CREATE PROCEDURE dbo.SP_update_employee
	@id INTEGER,
	@firstName VARCHAR(50) ,
	@lastName VARCHAR(50),
	@gender VARCHAR(50), 
	@birthdate DATETIME,
	@phone VARCHAR(20),
	@employeeAddress VARCHAR(250),
	@email VARCHAR(100), 
	@startWorkingDate DATETIME,
	@employeeStatus VARCHAR(100),
	@employeeRole VARCHAR(50)
AS
Update dbo.Employees
SET
	firstName=@firstName,
	lastName=@lastName,
	gender=@gender,
	birthdate=@birthdate,
	phone=@phone,
	employeeAddress=@employeeAddress,
	email=@email,
	startWorkingDate=@startWorkingDate,
	employeeStatus=@employeeStatus,
	employeeRole=@employeeRole
WHERE id=@id




CREATE PROCEDURE dbo.SP_check_employee_homeclass
			@employeeId INTEGER,
			@className VARCHAR(50) 
AS
BEGIN
    -- בדיקה ישירה אם יש קשר בין הכיתה למורה והחזרת התוצאה
    SELECT CASE 
               WHEN EXISTS (SELECT 1 FROM dbo.HomeroomTeachers WHERE teacherId = @employeeId AND className = @className)
               THEN 1
               ELSE 0 
           END AS IsLinked
END


CREATE PROCEDURE dbo.SP_update_teacher_homerooms 
	@teacherId INTEGER,
	@className VARCHAR(50),
	@flag INTEGER 
AS
BEGIN
    -- בדיקה אם flag הוא 1
    IF @flag = 1
    BEGIN
        -- בדיקה אם הרשומה קיימת בטבלה
        IF NOT EXISTS (
            SELECT 1 
            FROM dbo.HomeroomTeachers 
            WHERE teacherId = @teacherId AND className = @className
        )
        BEGIN
            -- הוספת הרשומה אם היא לא קיימת
            INSERT INTO dbo.HomeroomTeachers (teacherId, className)
            VALUES (@teacherId, @className);
        END
    END
    -- בדיקה אם flag הוא 0
    ELSE IF @flag = 0
    BEGIN
        -- בדיקה אם הרשומה קיימת בטבלה
        IF EXISTS (
            SELECT 1 
            FROM dbo.HomeroomTeachers 
            WHERE teacherId = @teacherId AND className = @className
        )
        BEGIN
            -- מחיקת הרשומה אם היא קיימת
            DELETE FROM dbo.HomeroomTeachers
            WHERE teacherId = @teacherId AND className = @className;
        END
    END
END


