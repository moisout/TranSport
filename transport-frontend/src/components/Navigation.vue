<template>
  <v-navigation-drawer
    class="nav-bar"
    :mini-variant.sync="open"
    permanent
    width="300"
    stateless
    floating
    elevation="4"
    absolute
  >
    <v-list dense>
      <v-list-item
        v-for="item in items"
        :key="item.title"
        link
        class="list-item-anim"
        :class="getCurrentRouteColor(item.route)"
        @click="setRoute(item.route)"
      >
        <v-list-item-icon>
          <v-icon color="secondary">{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <template v-slot:append>
      <v-list-item bottom class="list-item-anim">
        <v-list-item-avatar>
          <v-icon :color="user.isLoggedIn() ? 'accent' : 'primary'">mdi-account-circle-outline</v-icon>
        </v-list-item-avatar>

        <v-list-item-title>{{ user.getEmail() || 'Nicht eingeloggt' }}</v-list-item-title>
      </v-list-item>
    </template>
  </v-navigation-drawer>
</template>

<script>
import UserStore from '@/store/user'

export default {
  name: 'navigation',
  data: () => ({
    items: [
      { title: 'Home', route: '', icon: 'mdi-home-outline' },
      { title: 'Anlässe', route: 'anlaesse', icon: 'mdi-calendar-text-outline' },
      { title: 'Spieler', route: 'spieler', icon: 'mdi-account-group-outline' },
      { title: 'Fahrer', route: 'fahrer', icon: 'mdi-account-card-details-outline' },
      { title: 'Fahrzeuge', route: 'fahrzeuge', icon: 'mdi-car-multiple' },
      { title: 'Vereinsfahrzeuge', route: 'vereinsfahrzeuge', icon: 'mdi-bus-school' }
    ],
    user: UserStore
  }),
  props: {
    drawer: Boolean
  },
  computed: {
    open: {
      get() { return this.drawer },
      set() { }
    }
  },
  methods: {
    getCurrentRouteColor(route) {
      console.log(this.$route, route)
      return this.$route.path.replace('/', '') === route ? 'accent' : ''
    },
    setRoute(route) {
      this.$router.push(`/${route}`)
    }
  }
}
</script>

<style lang="scss">
.list-item-anim {
  justify-content: flex-start !important;
  padding: 0 16px 0 26px !important;
  transition: background-color 300ms;

  &.accent {
    * {
      color: #fff !important;
    }

    .v-icon {
      color: #fff !important;
    }
  }
}

.nav-bar {
  margin-top: 56px;
  max-height: calc(100% - 56px);
}
</style>>
