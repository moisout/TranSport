export default {
  state: {
    email: null
  },
  login(email, password) {
    return new Promise((resolve, reject) => {
      this.email = email
      resolve(email)
    })
  },
  getEmail() {
    return this.email
  },
  isLoggedIn() {
    return Boolean(this.email)
  }
}
