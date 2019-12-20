<template>
  <v-app>
    <v-app-bar app color="secondary" dark>
      <!-- <div class="sidebar-triangle-container">
        <div class="sidebar-triangle accent"></div>
      </div>-->
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <h1 class="white--text mr-2">Transport</h1>

      <v-spacer></v-spacer>

      <v-btn href="#" text>
        <v-icon class="mr-2">mdi-information-outline</v-icon>
        <span class>Support</span>
      </v-btn>

      <v-btn href="#" text>
        <v-icon class="mr-2">mdi-help-circle-outline</v-icon>
        <span class>Hilfe</span>
      </v-btn>
    </v-app-bar>
    <Navigation ref="navigation" :drawer="!drawer" />
    <v-content class="site-content">
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
import Navigation from '@/components/Navigation'
import UserStore from '@/store/user'

export default {
  name: 'App',
  components: {
    Navigation
  },
  data: () => ({
    drawer: false,
    user: UserStore.state
  })
}
</script>

<style lang="scss">
.sidebar-triangle-container {
  height: 100%;
  width: 80px;
  transition: width 200ms cubic-bezier(0.4, 0, 0.2, 1);
  overflow: hidden;
  position: absolute;
  left: 0;

  .sidebar-triangle {
    position: absolute;
    width: 80px;
    height: 100%;
    margin: 0;
    top: 0;
    left: 0;
    transition: width 200ms cubic-bezier(0.4, 0, 0.2, 1);
    clip-path: polygon(0% 0%, 100% 100%, 0% 100%);
  }
}
.site-content {
  margin-left: 80px;
}
</style>
