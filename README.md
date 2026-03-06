📝 ToDo List App - Full Stack Project
אפליקציית ניהול משימות (ToDo List) מקיפה הכוללת צד שרת ב-.NET וצד לקוח ב-React. הפרויקט מאפשר ניהול מלא של משימות (CRUD) עם שמירה במסד נתונים MySQL.

🚀 טכנולוגיות
Backend:
.NET 9 (Minimal API)

Entity Framework Core

MySQL Database

Swagger (לתיעוד ובדיקת ה-API)

Frontend:
React (Hooks: useState, useEffect)

Axios לתקשורת מול השרת

CSS3 עם פונטים מ-Google Fonts (Poppins)

🛠 איך מריצים את הפרויקט?
1. צד שרת (Backend)
ודאו ששרת MySQL פועל במחשבכם.

פתחו את תיקיית ה-Server ב-VS Code.

עדכנו את מחרוזת החיבור (Connection String) בקובץ appsettings.json עם הסיסמה שלכם ל-MySQL.

פתחו טרמינל והריצו:

Bash
dotnet watch run
השרת ירוץ בכתובת: http://localhost:5095

2. צד לקוח (Frontend)
פתחו את תיקיית ה-Client בטרמינל חדש.

התקינו את התלויות (בפעם הראשונה בלבד):

Bash
npm install
הריצו את האפליקציה:

Bash
npm start
האתר ייפתח בכתובת: http://localhost:3000

🌟 פיצ'רים עיקריים
הוספת משימה: הזנת טקסט ולחיצה על Enter.

סימון לביצוע: לחיצה על Checkbox מעדכנת את הסטטוס ב-DB (כולל תיקון לוגי לשמירת שם המשימה).

מחיקה: הסרת משימות בלחיצה על כפתור המחיקה.

עיצוב מודרני: שימוש ב-Shadows, פונט Poppins וממשק נקי.

📂 מבנה הפרויקט
TodoApi-Server/ - קוד ה-C# המנהל את ה-API והגישה לנתונים.

ToDoListReact-Client/ - קוד ה-React הכולל את רכיבי ה-UI והשירותים.

Item.cs - המודל המייצג משימה בבסיס הנתונים.

service.js - שכבת התקשורת (Service layer) שמחברת בין ה-React ל-API.

✍️ יוצרת הפרויקט
פותח על ידי תמר וולפא כחלק מפרויקט לימודי בניהול מערכות Full-stack.
