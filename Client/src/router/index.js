import { createRouter, createWebHistory } from "vue-router";
import DashboardPage from '../components/DashboardPage.vue'
import LoginPage from '../components/LoginPage.vue'
import TeacherInsert from '../components/TeacherInsert.vue'
import StudentInsert from '../components/FlightInsert.vue'


export default createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/dashboard',
          name: 'administration-dashboard',
          component: DashboardPage
        },
        { 
          path: '/login',
          name: 'login', 
          component: LoginPage,
          alias: '/' 
        },
        { 
          path: '/student',
          name: 'student-insert', 
          component: StudentInsert
        },
        { 
          path: '/teacher',
          name: 'teacher-insert', 
          component: TeacherInsert
        }
    ]
})