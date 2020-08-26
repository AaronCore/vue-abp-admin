import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import './plugins/element.js'
// 导入全局样式表
import './assets/css/global.css'
// 导入图标样式
import './assets/css/font-awesome.min.css'


// 配置请求的跟路径
axios.defaults.baseURL = 'http://127.0.0.1:6060/'

// axios.interceptors.request.use(config => {
//     config.headers.Authorization = window.sessionStorage.getItem('token')
//     return config
// })

Vue.prototype.$http = axios

Vue.config.productionTip = false

new Vue({
    router,
    render: h => h(App)
}).$mount('#app')