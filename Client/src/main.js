import { createApp } from 'vue'
import App from './App.vue'
import axios from 'axios'
import ApiPlugin from './plugins/api'
import LoadPlugin from './plugins/load'
import router from './router'
import store from './store/index'
import Select2 from 'vue3-select2-component';

const axiosInstance = axios.create({
    baseURL: 'https://nure-test-platform.azurewebsites.net/',
    withCredentials: true,
    headers: {
      accept: 'application/json'  
    }
})

const app = createApp(App)
app.config.globalProperties.$axios = { ...axiosInstance }
app.component('Select2', Select2)
app.use(ApiPlugin)
app.use(LoadPlugin)
app.use(store)
app.use(router)
app.mount('#app')