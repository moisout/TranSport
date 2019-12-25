<template>
  <div class="home">
    <v-container fluid>
      <v-row>
        <v-card
          class="mx-auto"
          max-width="344"
          v-for="(anlass, id) in anlaesse"
          :key="id"
          cols="12"
          xs="12"
          sm="6"
          md="4"
          lg="3"
          xl="2"
        >
          <v-card-title class="primary display-1">{{anlass.titel}}</v-card-title>
          <v-card-text>
            <v-simple-table>
              <template v-slot:default>
                <tbody>
                  <tr>
                    <td>Datum</td>
                    <td>{{ anlass.datum }}</td>
                  </tr>
                  <tr>
                    <td>Zeit</td>
                    <td>{{ anlass.zeit }}</td>
                  </tr>
                  <tr>
                    <td>Teilnehmer</td>
                    <td>{{ anlass.teilnehmer }}</td>
                  </tr>
                  <tr>
                    <td>Adresse</td>
                    <td>{{ anlass.adresse }}</td>
                  </tr>
                  <tr>
                    <td>Ort</td>
                    <td>{{ anlass.ort }}</td>
                  </tr>
                </tbody>
              </template>
            </v-simple-table>
          </v-card-text>
        </v-card>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import DataStore from '@/store/data'

export default {
  name: 'home',
  components: {
  },
  data: () => ({
    anlaesse: DataStore.anlaesse
  })
}
</script>
