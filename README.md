# 🚀 Full-Stack ToDo Manager
### .NET 9 API + React Modern Interface

![Backend](https://img.shields.io/badge/Backend-.NET%209-purple?style=for-the-badge&logo=dotnet)
![Frontend](https://img.shields.io/badge/Frontend-React-blue?style=for-the-badge&logo=react)
![Database](https://img.shields.io/badge/Database-MySQL-orange?style=for-the-badge&logo=mysql)

---

## 📝 אודות הפרויקט
אפליקציית ToDo מודרנית המשלבת צד שרת עוצמתי וצד לקוח אינטראקטיבי. הפרויקט נבנה מתוך דגש על לוגיקת תקשורת תקינה בין ה-Frontend ל-Backend ופתרון בעיות סנכרון נתונים.



## ✨ פיצ'רים מרכזיים
* **ניהול משימות מלא (CRUD):** הוספה, צפייה, עדכון סטטוס ומחיקה.
* **לוגיקת עדכון חסינה:** טיפול בבעיית אובדן נתונים ב-Minimal API על ידי שליפה ועדכון משולב.
* **עיצוב Poppins:** שימוש בפונטים מודרניים וחוויית משתמש נקייה.
* **תשתית Docker:** הפרויקט כולל Dockerfile מוכן לפריסה מהירה.

---

## 🛠 המבנה הטכנולוגי

| שכבה | טכנולוגיה | תפקיד |
| :--- | :--- | :--- |
| **Client** | React 18 | ממשק משתמש וניהול State |
| **Server** | .NET 9 | ניהול API וניתוב בקשות |
| **ORM** | EF Core | עבודה מול מסד הנתונים |
| **API Client** | Axios | ביצוע קריאות HTTP אסינכרוניות |

---

## ⚙️ הוראות הפעלה

### 1️⃣ צד השרת (Backend)
יש לוודא שמותקן שרת MySQL ולעדכן את ה-Connection String ב-`appsettings.json`.
```bash
# כניסה לתיקיית השרת
cd TodoApi-Server

# הרצה במצב פיתוח
dotnet watch run
2️⃣ צד הלקוח (Frontend)
Bash
# כניסה לתיקיית הלקוח
cd ToDoListReact-Client

# התקנת תלויות
npm install

# הרצת האפליקציה
npm start
📂 מבנה התיקיות העיקרי
TodoApi-Server/ - לוגיקת צד השרת, מודלים וחיבור ל-DB.

service.js - שכבת השירות המרכזת את כל הקריאות ל-API.

App.js - הרכיב המרכזי של האפליקציה ב-React.

✍️ מוגש ע"י:
Tamar Wolpe Full Stack Developer Student
