import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router/index.js'
import './assets/css/tailwind.css'
import vue3GoogleLogin from 'vue3-google-login';

// createApp(App)
//   .use(router)
//   .mount('#app');
const app = createApp(App);

// Cấu hình Google Login Plugin với Client ID của bạn
app.use(vue3GoogleLogin, {
  clientId: '741925959310-7eikftjurlq742fq9degqlt8pehk9ofn.apps.googleusercontent.com'
});

app.use(router);

app.mount('#app');
