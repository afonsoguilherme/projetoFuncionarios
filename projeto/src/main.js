import Vue from 'vue'
import App from './App.vue'
import VueResoruse from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResoruse);

new Vue({
  render: h => h(App),
}).$mount('#app')
