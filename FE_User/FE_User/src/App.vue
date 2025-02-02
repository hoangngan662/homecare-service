<template>
  <div id="app">
    <div v-if="$route.path.includes('/login') || $route.path.includes('/register')">
      <div class="bg-white dark:bg-gray-800 dark:border-gray-700">
        <router-view />
      </div>
    </div>
    <div v-else>
      <Header />
      <div class="bg-white dark:bg-gray-800 dark:border-gray-700">
        <router-view />
      </div>
      <Footer/>
    </div>
    <DarkButton />

  </div>
</template>

<script>
import Header from './components/Common/Header.vue';
import DarkButton from './components/Common/DarkButton.vue';
import Footer from './components/Common/Footer.vue';
export default {
  components: {
    Header,
    DarkButton,
    Footer
  },
};
</script>

<style>
#app {
  padding: 0;
}

body {
  font-family: 'Roboto', sans-serif;
  margin: 0;
  background-color: #ffffff;
}

h1 {
  margin: 0 0 0 0;
}

h2 {
  margin: 0 0 0 0;
}

h3 {
  margin: 0 0 0 0;
}
</style>
