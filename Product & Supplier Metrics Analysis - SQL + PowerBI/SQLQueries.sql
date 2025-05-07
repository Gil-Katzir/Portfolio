
--יצירת הטבלאות
CREATE TABLE CUSTOMERS (
Email Varchar (40) NOT NULL PRIMARY KEY,
FirstName Varchar (20) NOT NULL,
LastName Varchar (20),
PhoneNumber Varchar (13)
)
CREATE TABLE FLOWERSHOPS (
ShopID Varchar (20) NOT NULL PRIMARY KEY,
ShopName Varchar (20) NOT NULL,
Country Varchar (40) 
)

CREATE TABLE CREDITCARDS (
CCNumber Varchar (16) NOT NULL PRIMARY KEY,
OwnerID Varchar(9) NOT NULL,
ExpiredMonth Varchar (2) NOT NULL,
ExpiredYear Int NOT NULL,
CVV Varchar (3) NOT NULL
)

CREATE TABLE ORDERS (
OrderID Varchar (20) NOT NULL PRIMARY KEY,
CCNumber Varchar (16) FOREIGN KEY 
                      REFERENCES CREDITCARDS (CCNumber),
Email Varchar (40) FOREIGN KEY 
                   REFERENCES CUSTOMERS (Email),
OrderDT DateTime,
Country Varchar (40),
City Varchar (40) NOT NULL,
ZIPCode Varchar (10),
Street Varchar (20),
StreetNumber smallInt,
DeliveryDate Date NOT NULL,
GreetingCard Varchar (300),

)

CREATE TABLE PRODUCTS (
ProductID Varchar (20) NOT NULL PRIMARY KEY,
ShopID Varchar (20) FOREIGN KEY 
                    REFERENCES FLOWERSHOPS (ShopID),
ProductName Varchar (50) NOT NULL,
Category Varchar (20),
ProductPrice Decimal (5,2) NOT NULL
)

-- יצירת טבלת SEARCHS
CREATE TABLE SEARCHS (
    IPAddress Varchar(20) NOT NULL,
    SearchDT DateTime NOT NULL,
    Email Varchar(40),
    LeadsToOrder Varchar(20) NULL,
    Text Varchar(100),
    PRIMARY KEY (IPAddress, SearchDT),
    CONSTRAINT FK_Email_Search FOREIGN KEY (Email) REFERENCES CUSTOMERS(Email),
    CONSTRAINT FK_OrderSearch FOREIGN KEY (LeadsToOrder) REFERENCES ORDERS(OrderID)
)

CREATE TABLE REVIEWS (
ProductID Varchar (20) NOT NULL,
ReviewDT DateTime NOT NULL,
	     PRIMARY KEY (ProductID,ReviewDT),
Email Varchar (40) FOREIGN KEY 
                   REFERENCES CUSTOMERS (Email),
NickName Varchar (20),
Summary Varchar (30),
Review Varchar (300)

CONSTRAINT FK_ProductREV FOREIGN KEY (ProductID)
                      REFERENCES PRODUCTS (ProductID)
)

CREATE TABLE INCLUDES (
OrderID Varchar (20) NOT NULL,
ProductID Varchar (20) NOT NULL,
	     PRIMARY KEY (OrderID, ProductID),
Quantity Int,

CONSTRAINT FK_OrderINC FOREIGN KEY (OrderID)
                       REFERENCES ORDERS (OrderID),

CONSTRAINT FK_ProductINC FOREIGN KEY (ProductID)
                         REFERENCES PRODUCTS (ProductID)
)

CREATE TABLE SUPPLYS (
OrderID Varchar (20) NOT NULL,
ShopID Varchar (20) NOT NULL,
	   PRIMARY KEY (OrderID, ShopID),

CONSTRAINT FK_OrderSUP FOREIGN KEY (OrderID)
                       REFERENCES ORDERS (OrderID),

CONSTRAINT FK_ShopSUP FOREIGN KEY (ShopID)
                         REFERENCES FLOWERSHOPS (ShopID)
)


CREATE TABLE FINDINGS (
IPAddress Varchar (20) NOT NULL,
SearchDT DateTime NOT NULL,
ProductID Varchar (20) NOT NULL,
	   PRIMARY KEY (IPAddress, SearchDT, ProductID),

CONSTRAINT FK_IP_DT_FIND FOREIGN KEY (IPAddress, SearchDT)
                     REFERENCES SEARCHS (IPAddress, SearchDT),

CONSTRAINT FK_ProductFIND FOREIGN KEY (ProductID)
                            REFERENCES PRODUCTS (ProductID)

)

--הוספת אילוצי בדיקה 
ALTER TABLE CUSTOMERS
ADD CONSTRAINT CK_Email CHECK (Email LIKE '%@%.%'), --תבנית קבועה של אימייל
    CONSTRAINT CK_PhoneNumber  CHECK (PhoneNumber LIKE '+[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') --מספר טלפון בינלאומי

ALTER TABLE CREDITCARDS
ADD CONSTRAINT CK_CC CHECK (LEN(CCNumber) = 16 AND CCNumber NOT LIKE '%[^0-9]%'), --מספר כרטיס אשראי מכיל 16 ספרות בלבד
    CONSTRAINT CK_OwnerID CHECK (LEN(OwnerID)=9 AND OwnerID NOT LIKE '%[^0-9]%'), --ת"ז מכילה 9 מספרים בלבד
    CONSTRAINT CK_CCMonth CHECK (ExpiredMonth IN ('01','02','03','04','05','06','07','08','09','10','11','12')), --חודשים בתבנית קבועה בלבד 
	CONSTRAINT CK_CCYear CHECK (ExpiredYear > 2023) , --הכנסת שנת תפוגה תקינה
	CONSTRAINT CK_CVV  CHECK (CVV LIKE '[0-9][0-9][0-9]') --מכיל 3 ספרות בלבד

ALTER TABLE PRODUCTS
ADD CONSTRAINT CK_ProductPrice CHECK (ProductPrice > 0) --מחיר לא יכול להיות שלילי

ALTER TABLE INCLUDES
ADD CONSTRAINT CK_Quantity CHECK (Quantity > 0) --בהזמנה של מוצר ישנו לפחות מוצר אחד

--טבלאות חיפוש 
CREATE TABLE COUNTRIES (-- טבלת חיפוש שמציגה את המדינות שהאתר עובד איתן 
Country Varchar (40) PRIMARY KEY NOT NULL)

INSERT INTO COUNTRIES (Country) VALUES 
('UK'),('France'), ('Germany'), ('Netherlands'), ('Italy'), ('Spain'), ('Belgium')

ALTER TABLE FLOWERSHOPS 
ADD CONSTRAINT FK_Country FOREIGN KEY (Country) 
                          REFERENCES COUNTRIES (Country) 

CREATE TABLE CATEGORIES ( -- טבלת חיפוש שמציגה את קטגוריות המוצרים 
Category Varchar (20) PRIMARY KEY NOT NULL)

INSERT INTO CATEGORIES (Category) VALUES 
('BIRTHDAY'),('MARRIAGE'),('THANK YOU'),('CHRISTMAS')

ALTER TABLE PRODUCTS 
ADD CONSTRAINT FK_Category FOREIGN KEY (Category) 
                           REFERENCES CATEGORIES (Category)



--מחיקת טבלאות הקשרים
DROP TABLE FINDINGS
DROP TABLE SUPPLYS
DROP TABLE INCLUDES
DROP TABLE REVIEWS
DROP TABLE SEARCHS

-- מחיקת טבלאות עצמאיות
DROP TABLE PRODUCTS
DROP TABLE ORDERS
DROP TABLE CREDITCARDS
DROP TABLE FLOWERSHOPS
DROP TABLE CUSTOMERS

-- מחיקת טבלאות החיפוש
DROP TABLE CATEGORIES
DROP TABLE COUNTRIES


--שאילתות 

--שאילתה 1

SELECT TOP 1 P.Category, Selling= COUNT (*), Income = SUM (P.ProductPrice * I.Quantity)
FROM         PRODUCTS AS P JOIN 
             INCLUDES AS I ON P.ProductID = I.ProductID  JOIN
             ORDERS AS O ON I.OrderID = O.OrderID
WHERE        YEAR(O.OrderDT)=2023
GROUP BY     P.Category
ORDER BY     Selling DESC


--שאילתה 2

SELECT   F.Country, Selling= SUM(I.Quantity*P.ProductPrice)
FROM     PRODUCTS AS P JOIN INCLUDES AS I ON P.ProductID = I.ProductID JOIN 
         FLOWERSHOPS AS F ON F.ShopID = P.ShopID JOIN 
         ORDERS AS O ON O.OrderID= I.OrderID
WHERE    MONTH (O.OrderDT) IN ('12','11','02') 
GROUP BY F.Country
HAVING   SUM(I.Quantity*P.ProductPrice) < 500
ORDER BY Selling



--שאילתה 3

SELECT SELLS.[Full Name],  SELLS.Email
FROM (
        -- הלקוחות שביצעו לפחות הזמנה אחת בכללי
        SELECT   [Full Name]= C.FirstName + ' ' + C.LastName, 
       	         [Number Of Orders] = COUNT (*),	       
                 O.Email  
        FROM     ORDERS AS O JOIN CUSTOMERS AS C ON O.Email = C.Email
        GROUP BY O.Email ,C.FirstName, C.LastName
        HAVING   COUNT (*) >= 1
      ) AS SELLS
 WHERE SELLS.[Full Name] NOT IN (
                                 -- לקוחות שקנו בשנה האחרונה 
                             SELECT  DISTINCT [Full Name]= C.FirstName + ' ' + C.LastName
                             FROM ORDERS AS O JOIN CUSTOMERS AS C ON O.Email = C.Email
                             WHERE  YEAR(GetDate()) = YEAR(OrderDT)
                                )




--שאילתה 4

SELECT TOP 5 O.Country, 
             [Country Total Income] = SUM (I.Quantity*P.ProductPrice), 
             [Precent Income] =  SUM (I.Quantity*P.ProductPrice) / T.[Total Income]
FROM         INCLUDES AS I JOIN 
             PRODUCTS AS P ON I.ProductID = P.ProductID JOIN 
             ORDERS AS O ON I.OrderID = O.OrderID
             CROSS JOIN (
	                 --סך ההכנסות של האתר 
	                  SELECT [Total Income] = SUM (I.Quantity*P.ProductPrice)
                         FROM   INCLUDES AS I JOIN 
                                PRODUCTS AS P ON I.ProductID=P.ProductID	 
	                  ) AS T 
GROUP BY     T.[Total Income], O.Country
ORDER BY     2 DESC





 --שאילתה 5

UPDATE PRODUCTS
SET ProductPrice = ProductPrice * 1.2
        WHERE Category = 'Best Seller' 
		AND ProductID IN (
                               SELECT I.ProductID
                               FROM INCLUDES AS I JOIN ORDERS AS O ON I.OrderID = O.OrderID
                               WHERE  YEAR(O.OrderDT) = YEAR(GETDATE())
                               GROUP BY I.ProductID
                               HAVING SUM(I.Quantity) >50
	                        )



--שאילתה 6

-- שלב 1: לקוחות שביצעו בשנת 2024 פחות הזמנות ממוצע ההזמנות במדינה בשנה זו
SELECT    C.Email, [Full Name] = C.FirstName +''+ C.LastName
FROM      CUSTOMERS AS C LEFT JOIN ORDERS AS O ON C.Email = O.Email
                    JOIN (
                         --פולט טבלה של מספר הזמנות בכל מדינה
                          SELECT   Country,
                                   AverageOrders = (CAST(COUNT(OrderID)AS   
                                   float)/COUNT(DISTINCT Email)), 
                                   V=COUNT(DISTINCT Email)
                          FROM     ORDERS
                          WHERE    YEAR(OrderDT) = 2024
	       	     GROUP BY Country
			    ) AS CountryOrderCounts ON O.Country=CountryOrderCounts.Country
WHERE    YEAR(OrderDT) = 2024
GROUP BY C.Email, C.FirstName, C.LastName ,CountryOrderCounts.AverageOrders
HAVING   COUNT(O.OrderID) < CountryOrderCounts.AverageOrders

INTERSECT

-- שלב 2: לקוחות שביצעו לפחות חיפוש אחד שלא הוביל להזמנה בשנת 2024
SELECT S.Email, [Full Name] = C.FirstName +''+ C.LastName
FROM SEARCHS AS S JOIN CUSTOMERS AS C ON S.Email=C.Email
WHERE YEAR (SearchDT) = 2024 AND LeadsToOrder IS NULL



--שאילתה 7

SELECT       DISTINCT
             [Negative Product Rank]= DENSE_RANK() OVER (ORDER BY Amount DESC),
             BadReviews.ProductID, 
             BadReviews.Amount,  
	      [Total Ordered Product] = SUM (I.Quantity) OVER (PARTITION BY      
                                       BadReviews.ProductID)
FROM        (
             --מספר הביקורות השליליות לכל מוצר
             SELECT ProductID, Amount= COUNT(*)  
             FROM REVIEWS
             WHERE Review LIKE  '%ugly%' OR Review LIKE '%smelly%' OR Review LIKE '%bad%'    
                          OR Review LIKE '%disappointed%' OR Review LIKE '%old%'
             GROUP BY ProductID
            ) AS BadReviews LEFT JOIN INCLUDES AS I ON BadReviews.ProductID=I.ProductID
ORDER BY    [Negative Product Rank]



--שאילתה 8

SELECT   [Month Number], ActiveCustomers, MonthlyGrowth = CAST((ActiveCustomers -    
         LAG(ActiveCustomers) OVER (ORDER BY [Month Number])) AS REAL) /    
         (LAG(ActiveCustomers) OVER (ORDER BY [Month Number])) *100  ,
         [Quartile Rank] = NTILE(4) OVER (ORDER BY ActiveCustomers DESC)

FROM  (    SELECT    [Month Number]= Month(orderDT) ,
                    ActiveCustomers= Count (Distinct Email)
           FROM     ORDERS
           WHERE    YEAR (OrderDT) = 2024
           GROUP BY Month (OrderDT)
      )    AS MonthSales

ORDER BY [Month Number]


--WITH מורכבת

WITH
--  שאילתה 1: סיכום ההזמנות והרווחים לכל מוצר
ProductOrderSummary AS (
    SELECT   P.ProductID, P.ProductName, P.ShopID,
             TotalOrders= COUNT(I.OrderID) ,
             TotalQuantitySold= SUM(I.Quantity) ,
             TotalRevenue= SUM(I.Quantity * P.ProductPrice) ,
             AvgRevenuePerOrder= AVG(I.Quantity * P.ProductPrice)
    FROM     PRODUCTS LEFT JOIN INCLUDES as I ON P.ProductID = I.ProductID
    GROUP BY P.ProductID, P.ProductName, P.ShopID
),

--  שאילתה 2: סיכום החיפושים לכל מוצר
ProductSearchSummary AS (
   SELECT    P.ProductID,  P.ProductName, TotalSearches= COUNT(F.SearchDT)  
    FROM     PRODUCTS as P LEFT JOIN FINDINGS as F ON P.ProductID = F.ProductID
    GROUP BY P.ProductID, P.ProductName
),

--  שאילתה 3: שיעור החיפושים פר מוצר
ProductSearchRate AS (
    SELECT  PSS.ProductID, PSS.ProductName, PSS.TotalSearches, POS.TotalOrders,
-- כל כמה פעמים שהמוצר עלה בחיפוש, התבצעה הזמנה של מוצר זה
            CASE WHEN POS.TotalOrders > 0 THEN (CAST(PSS.TotalSearches AS FLOAT) /    
                      POS.TotalOrders) * 100
                 ELSE 0 END AS SearchToOrderRate
    FROM ProductSearchSummary AS PSS LEFT JOIN ProductOrderSummary as POS ON     
         PSS.ProductID = POS.ProductID
),

--  שאילתה 4: חישוב הרווח הכולל לכל חנות
ShopTotalRevenue AS (
    SELECT   ShopID, [Total Product's Shop Revenue]= SUM(TotalRevenue)
    FROM     ProductOrderSummary
    GROUP BY ShopID
),

--  שאילתה 5: סיכום ההזמנות לכל מוצר לפי חודש
ProductOrderByMonth AS (
    SELECT   P.ProductID, OrderMonth= MONTH(O.OrderDT) ,OrderCount= COUNT(O.OrderID)
    FROM     PRODUCTS as P JOIN INCLUDES I ON P.ProductID = I.ProductID  
             JOIN ORDERS as O ON I.OrderID = O.OrderID
    GROUP BY P.ProductID, MONTH(O.OrderDT)
),


--  שאילתה 6: החודש עם הכי הרבה הזמנות עבור כל מוצר
MaxOrderMonth AS (
     SELECT ProductID, [Successful Month] 
     FROM (
           SELECT POM.ProductID,
                  [Successful Month]= POM.OrderMonth ,
                  MaxOrderCount= POM.OrderCount ,
                  ROW_NUMBER() OVER (PARTITION BY POM.ProductID ORDER BY POM.OrderCount      
                                     DESC, POM.OrderMonth) AS RowNum
           FROM ProductOrderByMonth POM
          ) AS RankedMonths
    WHERE RowNum = 1
),

-- תת שאילתה 7: שילוב הנתונים למוצר
ProductSummary AS (
    SELECT POS.ProductID, POS.ProductName, POS.ShopID, POS.TotalOrders,   
           POS.TotalQuantitySold, POS.TotalRevenue,
           POS.AvgRevenuePerOrder, PSS.TotalSearches, PSR.SearchToOrderRate,
           STRE.[Total Product's Shop Revenue],
        CASE
            WHEN STRE.[Total Product's Shop Revenue] > 0 THEN (POS.TotalRevenue /   
                 STRE.[Total Product's Shop Revenue]) * 100
            ELSE 0 END AS RevenuePercentageForShop, MOM.[Successful Month]
    FROM   ProductOrderSummary as POS 
           LEFT JOIN ProductSearchSummary as PSS ON POS.ProductID = PSS.ProductID
           LEFT JOIN ProductSearchRate as PSR ON POS.ProductID = PSR.ProductID
           LEFT JOIN ShopTotalRevenue as STRE ON POS.ShopID = STRE.ShopID
           LEFT JOIN MaxOrderMonth as MOM ON POS.ProductID = MOM.ProductID
)

-- השאילתה הראשית: יצירת דו"ח
SELECT
    [ProductID]= PS.ProductID,
    [Product Name]= PS.ProductName,
    [Product's Shop] = PS.ShopID,
    [Total Orders]= PS.TotalOrders,
    [Total Quantity Sold]= PS.TotalQuantitySold,
    [Total Revenue]= PS.TotalRevenue,
    [Average Revenue Per Order]=PS.AvgRevenuePerOrder,
    [Total Searches]= PS.TotalSearches,
    [Search To Order Rate]= PS.SearchToOrderRate,
    [Revenue of Product for his Shop]= PS.RevenuePercentageForShop,
    PS.[Successful Month]
FROM ProductSummary as PS
ORDER BY PS.RevenuePercentageForShop DESC



--דוח עסקי VIEW

--חיפושים המובילים להזמנה
CREATE VIEW 
        SearchConversion AS
SELECT  s.IPAddress, YEAR= YEAR(S.SearchDT),
        LeadOrNot = CASE WHEN S.LeadsToOrder is NULL THEN 'Not Leading' ELSE 'Leading' END,      
        P.Category, O.Country
From     SEARCHS as S JOIN FINDINGS AS F ON S.IPAddress=F.IPAddress AND S.SearchDT=F.SearchDT    
        JOIN PRODUCTS AS P ON P.ProductID=F.ProductID
        LEFT JOIN ORDERS as O ON O.OrderID=S.LeadsToOrder

--סהכ הרווחים לפי חודש פר שנה
CREATE VIEW 
         ProfitByMonthYear AS
SELECT   O.Country, P.Category,
         OrderYear= YEAR(OrderDT)  ,
         OrderMonth= MONTH(OrderDT) ,
         TotalProfit = ISNULL(SUM(I.Quantity * P.ProductPrice), 0),
	  TotalProduct = SUM(I.Quantity)

FROM     ORDERS as O LEFT JOIN INCLUDES I ON O.OrderID = I.OrderID
         LEFT JOIN PRODUCTS as P ON I.ProductID = P.ProductID
GROUP BY MONTH(OrderDT), YEAR(OrderDT), O.Country, P.Category



--לוח מחוונים
CREATE VIEW 
      V_DASHBOARD AS
SELECT   O.OrderDT, YEAR = YEAR (O.OrderDT), O.OrderID, O.Email,
         P.ProductName, P.ProductID, I.Quantity, P.Category,
         F.ShopName, O.Country,
         Revnue = SUM (I.Quantity * P.ProductPrice)
FROM     ORDERS AS O JOIN INCLUDES AS I ON O.OrderID = I.OrderID
         JOIN PRODUCTS AS P ON I.ProductID = P.ProductID
         JOIN FLOWERSHOPS AS F ON P.ShopID = F.ShopID
GROUP BY O.OrderDT, O.OrderID, O.Email, P.ProductName, P.ProductID,
         I.Quantity, P.Category, F.ShopName,O.Country
