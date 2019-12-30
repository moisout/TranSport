import VueCookie from 'vue-cookie'

export default {
  state: {
    email: null
  },
  login(email, password) {
    let me = this
    return new Promise((resolve, reject) => {
      fetch('https://localhost:44362/Authentication.ashx', {
        method: 'POST',
        body: JSON.stringify({
          email: email,
          password: password
        })
      })
        .then(response => {
          if (response.ok) {
            return response.json()
          } else {
            console.log('error', response)
          }
        })
        .then(data => {
          console.log(data)
          VueCookie.set('ASP.NET_SessionId', data.sessionId, {
            expires: 1
          })
          me.email = email
          resolve(email)
        })
    })
  },
  getEmail() {
    return this.email
  },
  isLoggedIn() {
    let me = this
    return new Promise((resolve, reject) => {
      if (!me.email) {
        if (VueCookie.get('ASP.NET_SessionId')) {
          fetch('https://localhost:44362/GetUser.ashx', {
            method: 'POST',
            credentials: 'include'
          })
            .then(response => response.json())
            .then(data => {
              if (data) {
                if (data.sessionId && data.email) {
                  VueCookie.set('ASP.NET_SessionId', data.sessionId, {
                    expires: 1
                  })
                  me.email = data.email
                  resolve(Boolean(me.email))
                } else {
                  throw new Error('Error')
                }
              }
            })
            .catch(error => {
              reject(error)
            })
        } else {
          reject(new Error('Error'))
        }
      } else {
        resolve(true)
      }
    })
  }
}
