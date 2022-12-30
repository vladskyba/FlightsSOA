import { createRouter, createWebHistory } from "vue-router";
import DashboardPage from '../components/DashboardPage.vue'
import LoginPage from '../components/LoginPage.vue'
import FlightInsert from '../components/FlightInsert.vue'
import FlightSearch from '../components/SearchPage.vue'
import ReservationInsert from '../components/ReservationInsert.vue'
import ReservationsPage from '../components/ReservationsPage.vue'

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
          path: '/flight',
          name: 'flight-insert', 
          component: FlightInsert
        },
        { path: '/flightsSearch',
        name: 'flights-search',
        component: FlightSearch
        },
        {
          path: '/createReservation/:id',
          name: 'reservation-insert',
          component: ReservationInsert
        },
        {
          path: '/reservations',
          name: 'reservations',
          component: ReservationsPage
        }
    ]
})