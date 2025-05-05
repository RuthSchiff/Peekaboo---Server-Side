# Peekaboo - Server Side

###### Peekaboo - Server Side 
######    הוא פרויקט צד שרת שנכתב ב - C#  עבור חנות בגדי תינוקות.
 ###### הפרויקט בנוי במבנה רב-שכבתי (Multi-Layered Architecture) ומיועד לנהל את הלוגיקה העסקית, הגישה לנתונים, והאינטראקציה עם ה-API.

## מבנה הפרויקט

הפרויקט מחולק למספר שכבות עיקריות:

### 1. **Bll (Business Logic Layer)**
- אחראי על הלוגיקה העסקית של האפליקציה.
- קבצים עיקריים:
  - `Category_Bll.cs`
  - `Company_Bll.cs`
  - `Customer_Bll.cs`
  - `Order_Bll.cs`
  - `Order_details_Bll.cs`
  - `Product_Bll.cs`

### 2. **Dal (Data Access Layer)**
- אחראי על הגישה לנתונים והאינטראקציה עם בסיס הנתונים.
- קבצים עיקריים:
  - `Category_dal.cs`
  - `Company_Dal.cs`
  - `Customer_dal.cs`
  - `Order_dal.cs`
  - `Orders_detail_dal.cs`
  - `Product_dal.cs`

### 3. **Dto (Data Transfer Objects)**
- מכיל מחלקות להעברת נתונים בין השכבות.
- תיקיות עיקריות:
  - `dto_classes/`

### 4. **Ibll (Interfaces for Bll)**
- מכיל ממשקים עבור שכבת הלוגיקה העסקית.

### 5. **Idal (Interfaces for Dal)**
- מכיל ממשקים עבור שכבת הגישה לנתונים.

### 6. **WebApplication1**
- שכבת ה-API שמאפשרת אינטראקציה עם צד הלקוח.
- משתמשת ב-.NET 7.0 ומכילה קבצים הקשורים ל-Razor Pages.

## פונקציות בפרויקט:
# פונקציות בפרויקט Peekaboo - Server Side

## פונקציות לפי שכבות

### 1. **Bll (Business Logic Layer)**

שכבת הלוגיקה העסקית מכילה פונקציות שמטפלות בלוגיקה של האפליקציה. להלן הפונקציות העיקריות:

#### Category_Bll.cs
- `GetAllCategories()`: מחזירה את כל הקטגוריות.
- `GetCategoryById(int id)`: מחזירה קטגוריה לפי מזהה.
- `AddCategory(CategoryDto category)`: מוסיפה קטגוריה חדשה.
- `UpdateCategory(int id, CategoryDto category)`: מעדכנת קטגוריה קיימת.
- `DeleteCategory(int id)`: מוחקת קטגוריה לפי מזהה.

#### Company_Bll.cs
- `GetAllCompanies()`: מחזירה את כל החברות.
- `GetCompanyById(int id)`: מחזירה חברה לפי מזהה.
- `AddCompany(CompanyDto company)`: מוסיפה חברה חדשה.
- `UpdateCompany(int id, CompanyDto company)`: מעדכנת חברה קיימת.
- `DeleteCompany(int id)`: מוחקת חברה לפי מזהה.

#### Customer_Bll.cs
- `GetAllCustomers()`: מחזירה את כל הלקוחות.
- `GetCustomerById(int id)`: מחזירה לקוח לפי מזהה.
- `AddCustomer(CustomerDto customer)`: מוסיפה לקוח חדש.
- `UpdateCustomer(int id, CustomerDto customer)`: מעדכנת לקוח קיים.
- `DeleteCustomer(int id)`: מוחקת לקוח לפי מזהה.

#### Order_Bll.cs
- `GetAllOrders()`: מחזירה את כל ההזמנות.
- `GetOrderById(int id)`: מחזירה הזמנה לפי מזהה.
- `AddOrder(OrderDto order)`: מוסיפה הזמנה חדשה.
- `UpdateOrder(int id, OrderDto order)`: מעדכנת הזמנה קיימת.
- `DeleteOrder(int id)`: מוחקת הזמנה לפי מזהה.

#### Order_details_Bll.cs
- `GetOrderDetailsByOrderId(int orderId)`: מחזירה פרטי הזמנה לפי מזהה הזמנה.
- `AddOrderDetails(OrderDetailsDto details)`: מוסיפה פרטי הזמנה.
- `UpdateOrderDetails(int id, OrderDetailsDto details)`: מעדכנת פרטי הזמנה.
- `DeleteOrderDetails(int id)`: מוחקת פרטי הזמנה לפי מזהה.

#### Product_Bll.cs
- `GetAllProducts()`: מחזירה את כל המוצרים.
- `GetProductById(int id)`: מחזירה מוצר לפי מזהה.
- `AddProduct(ProductDto product)`: מוסיפה מוצר חדש.
- `UpdateProduct(int id, ProductDto product)`: מעדכנת מוצר קיים.
- `DeleteProduct(int id)`: מוחקת מוצר לפי מזהה.

---

### 2. **Dal (Data Access Layer)**

שכבת הגישה לנתונים מכילה פונקציות שמבצעות אינטראקציה עם בסיס הנתונים.

#### Category_dal.cs
- `GetAll()`: מחזירה את כל הקטגוריות מבסיס הנתונים.
- `GetById(int id)`: מחזירה קטגוריה לפי מזהה.
- `Insert(Category category)`: מוסיפה קטגוריה חדשה.
- `Update(Category category)`: מעדכנת קטגוריה קיימת.
- `Delete(int id)`: מוחקת קטגוריה לפי מזהה.

#### Company_Dal.cs
- `GetAll()`: מחזירה את כל החברות מבסיס הנתונים.
- `GetById(int id)`: מחזירה חברה לפי מזהה.
- `Insert(Company company)`: מוסיפה חברה חדשה.
- `Update(Company company)`: מעדכנת חברה קיימת.
- `Delete(int id)`: מוחקת חברה לפי מזהה.

#### Customer_dal.cs
- `GetAll()`: מחזירה את כל הלקוחות מבסיס הנתונים.
- `GetById(int id)`: מחזירה לקוח לפי מזהה.
- `Insert(Customer customer)`: מוסיפה לקוח חדש.
- `Update(Customer customer)`: מעדכנת לקוח קיים.
- `Delete(int id)`: מוחקת לקוח לפי מזהה.

#### Order_dal.cs
- `GetAll()`: מחזירה את כל ההזמנות מבסיס הנתונים.
- `GetById(int id)`: מחזירה הזמנה לפי מזהה.
- `Insert(Order order)`: מוסיפה הזמנה חדשה.
- `Update(Order order)`: מעדכנת הזמנה קיימת.
- `Delete(int id)`: מוחקת הזמנה לפי מזהה.

#### Orders_detail_dal.cs
- `GetByOrderId(int orderId)`: מחזירה פרטי הזמנה לפי מזהה הזמנה.
- `Insert(OrderDetails details)`: מוסיפה פרטי הזמנה.
- `Update(OrderDetails details)`: מעדכנת פרטי הזמנה.
- `Delete(int id)`: מוחקת פרטי הזמנה לפי מזהה.

#### Product_dal.cs
- `GetAll()`: מחזירה את כל המוצרים מבסיס הנתונים.
- `GetById(int id)`: מחזירה מוצר לפי מזהה.
- `Insert(Product product)`: מוסיפה מוצר חדש.
- `Update(Product product)`: מעדכנת מוצר קיים.
- `Delete(int id)`: מוחקת מוצר לפי מזהה.

---

### 3. **WebApplication1 (API Layer)**

שכבת ה-API מכילה פונקציות שמאפשרות אינטראקציה עם צד הלקוח.

#### Controllers
- `CategoryController`: מכיל פעולות לניהול קטגוריות.
- `CompanyController`: מכיל פעולות לניהול חברות.
- `CustomerController`: מכיל פעולות לניהול לקוחות.
- `OrderController`: מכיל פעולות לניהול הזמנות.
- `OrderDetailsController`: מכיל פעולות לניהול פרטי הזמנות.
- `ProductController`: מכיל פעולות לניהול מוצרים.

---

## הערות

- כל הפונקציות בשכבות השונות פועלות יחד כדי לספק פתרון מלא לניהול חנות בגדי תינוקות.
- ניתן להרחיב את הפונקציות או להתאים אותן לצרכים נוספים.



## דרישות מערכת

- **.NET 7.0**: הפרויקט מבוסס על פלטפורמת .NET 7.0.
- **מערכות הפעלה נתמכות**: Linux, macOS, Windows.

## התקנה והרצה

1. ודא ש-.NET 7.0 מותקן במערכת שלך.
2. פתח את קובץ הפתרון `Bll.sln` ב-Visual Studio.
3. בחר את פרויקט `WebApplication1` כפרויקט התחלתי.
4. הרץ את האפליקציה.

## מטרת הפרויקט

מטרת הפרויקט היא לספק פתרון צד שרת לניהול חנות בגדי תינוקות, כולל ניהול קטגוריות, מוצרים, הזמנות, ולקוחות.



---
