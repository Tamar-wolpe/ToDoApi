// import axios from 'axios';

// const apiUrl = "https://localhost:7271"

// export default {
//   getTasks: async () => {
//     const result = await axios.get(`${apiUrl}/items`)    
//     return result.data;
//   },

//   addTask: async(name)=>{
//     console.log('addTask', name)
//     //TODO
//     return {};
//   },

//   setCompleted: async(id, isComplete)=>{
//     console.log('setCompleted', {id, isComplete})
//     //TODO
//     return {};
//   },

//   deleteTask:async()=>{
//     console.log('deleteTask')
//   }
// };


// import axios from 'axios';

// // 💥 תיקון: הגדרת כתובת ה-Backend הנכונה (פורט 5095 + נתיב API)
// const apiUrl = "http://localhost:5095/api"

// export default {
    
//     // שליפת כל המשימות (GET)
//     getTasks: async () => {
//         // הנתיב המלא: http://localhost:5095/api/todoitems
//         const result = await axios.get(`${apiUrl}/todoitems`); 
//         return result.data;
//     },

//     // יצירת משימה חדשה (POST)
//     addTask: async(name) => {
//         return axios.post(`${apiUrl}/todoitems`, { 
//             name: name,
//             isComplete: false // משימה חדשה תמיד מתחילה כ-false
//         });
//     },

//     // עדכון מצב משימה (PUT)
//     setCompleted: async(id, isComplete) => {
//         // כדי לעדכן, אנחנו צריכים לשלוף קודם את השם הנוכחי (או לשלוח משהו קבוע)
//         // בפרויקטים כאלה, לרוב נשלח את כל האובייקט המלא לעדכון:
        
//         // הערה: נניח שצריך לשלוח גם את השם, במטלה זו נשלח שם קבוע כדוגמה,
//         // אבל עדיף לעדכן את הפונקציה ב-React שתעביר גם את השם.
        
//         // במקום זה, נשתמש ב-axios.put כדי לשלוח רק את הנתונים שאנחנו בטוחים בהם:
//         return axios.put(`${apiUrl}/todoitems/${id}`, {
//             id: id,
//             // משאירים את השם כפי שהוא אם ה-Client לא שולח אותו
//             name: "Updated Task", 
//             isComplete: isComplete
//         });
//     },
    
//     // מחיקת משימה (DELETE)
//     deleteTask: async(id) => {
//         // הנתיב המלא: http://localhost:5095/api/todoitems/{id}
//         return axios.delete(`${apiUrl}/todoitems/${id}`);
//     }
// };



// import axios from 'axios';

// const apiUrl = "http://localhost:5095/api"

// export default {
    
//     getTasks: async () => {
//         const result = await axios.get(`${apiUrl}/todoitems`); 
//         return result.data;
//     },

//     addTask: async(name) => {
//         return axios.post(`${apiUrl}/todoitems`, { 
//             name: name,
//             isComplete: false
//         });
//     },

//     setCompleted: async(id, isComplete, name = "Task Name") => {
//         // הערה: הוספתי את 'name' כארגומנט עם ערך ברירת מחדל כדי למנוע שגיאות 500
//         return axios.put(`${apiUrl}/todoitems/${id}`, {
//             id: id,
//             name: name, 
//             isComplete: isComplete
//         });
//     },
    
//     deleteTask: async(id) => {
//         return axios.delete(`${apiUrl}/todoitems/${id}`);
//     }
// };


// פתחי את service.js וודאי שכל הקוד נראה כך:
import axios from 'axios';

const apiUrl = "http://localhost:5095/api"

export default {
    
    getTasks: async () => {
        const result = await axios.get(`${apiUrl}/todoitems`); 
        return result.data;
    },

    addTask: async(name) => {
        return axios.post(`${apiUrl}/todoitems`, { 
            name: name,
            isComplete: false
        });
    },

    // 💥 התיקון הקריטי: אנחנו צריכים את השם כדי שה-PUT לא יקרוס
    // נניח שקוד ה-React שלך (App.js) שולח רק id ו-isComplete
    // לכן, אנחנו שולפים את המשימה קודם כדי לקבל את השם הנוכחי!
    setCompleted: async(id, isComplete) => {
        // 1. שליפת המשימה הנוכחית כדי לקבל את השם (Name)
        const currentTaskResult = await axios.get(`${apiUrl}/todoitems/${id}`);
        const currentTask = currentTaskResult.data;

        // 2. ביצוע עדכון (PUT) עם כל הנתונים הנדרשים (כולל השם!)
        return axios.put(`${apiUrl}/todoitems/${id}`, {
            id: id,
            name: currentTask.name, // ⬅️ שליחת השם המקורי
            isComplete: isComplete // שליחת הסטטוס החדש
        });
    },
    
    deleteTask: async(id) => {
        return axios.delete(`${apiUrl}/todoitems/${id}`);
    }
};