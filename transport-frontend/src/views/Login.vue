<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex xs12 sm10 md8>
        <v-card class="elevation-12 login-card">
          <v-toolbar color="secondary--text white" dark flat>
            <v-toolbar-title>Login</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form v-model="valid">
              <v-text-field
                label="Email"
                name="email"
                prepend-icon="mdi-account-outline"
                type="email"
                :rules="emailRules"
                v-model="email"
                required
              ></v-text-field>

              <v-text-field
                id="password"
                label="Password"
                name="password"
                prepend-icon="mdi-lock-outline"
                type="password"
                :rules="passwordRules"
                v-model="password"
                required
              ></v-text-field>
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-btn small text @click.stop="openRegister">Noch kein Account? Registrieren</v-btn>
            <v-spacer></v-spacer>
            <v-btn color="primary" @click.stop="login" :disabled="!valid">Login</v-btn>
          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import UserStore from '@/store/user'

export default {
  name: 'login',
  data: () => ({
    valid: false,
    email: null,
    password: null,
    emailRules: [
      v => !!v || 'Email erforderlich'
    ],
    passwordRules: [
      v => !!v || 'Passwort erforderlich'
    ]
  }),
  methods: {
    login() {
      if (this.email && this.password && this.valid) {
        UserStore.login(this.email, this.password)
        this.$router.push('/')
      }
    }
  }
}
</script>

<style type="scss">
.login-card {
  padding: 40px;
}
</style>
