<template>
  <div id="app">
    <div v-if="$route.path.includes('/login')||$route.path.includes('/register')">
      <div
        class="bg-white dark:bg-gray-800 dark:border-gray-700">
        <router-view />
      </div>
    </div>
    <div v-else>
      <Header />
      <SideBar />
      <div class="p-4 sm:ml-64">
        <div
          class="p-4 border-2 border-gray-200 bg-white border-dashed rounded-lg dark:bg-gray-800 dark:border-gray-700 mt-16">
          <router-view />
        </div>
      </div>
    </div>
    <DarkButton />

  </div>
</template>

<script>
import SideBar from './components/Common/SideBar.vue';
import Header from './components/Common/Header.vue';
import DarkButton from './components/Common/DarkButton.vue';
export default {
  components: {
    Header,
    SideBar,
    DarkButton
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
