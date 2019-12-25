<template>
  <div class="fahrzeuge">
    <v-data-table :headers="headers" :items="fahrzeuge">
      <template v-slot:item.typ="props">
        <v-edit-dialog
          :return-value.sync="props.item.typ"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.typ }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.typ"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.marke="props">
        <v-edit-dialog
          :return-value.sync="props.item.marke"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.marke }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.marke"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.farbe="props">
        <v-edit-dialog
          :return-value.sync="props.item.farbe"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.farbe }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.farbe"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.sitzplaetze="props">
        <v-edit-dialog
          :return-value.sync="props.item.sitzplaetze"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.sitzplaetze }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.sitzplaetze"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
    </v-data-table>
    <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
      {{ snackText }}
      <v-btn text @click="snack = false">Close</v-btn>
    </v-snackbar>
  </div>
</template>

<script>
import DataStore from '@/store/data'

export default {
  name: 'fahrzeuge',
  components: {
  },
  data: () => ({
    snack: false,
    snackColor: '',
    snackText: '',
    max25chars: v => v.length <= 25 || 'Input too long!',
    pagination: {},
    headers: [
      {
        text: 'Typ',
        align: 'left',
        sortable: false,
        value: 'typ'
      },
      { text: 'Marke', value: 'marke' },
      { text: 'Farbe', value: 'farbe' },
      { text: 'Sitzplätze', value: 'sitzplaetze' }
    ],
    fahrzeuge: DataStore.fahrzeuge
  }),
  methods: {
    save() {
      this.snack = true
      this.snackColor = 'success'
      this.snackText = 'Gespeichert'
    },
    cancel() {
    },
    open() {
    },
    close() {
      console.log('Dialog closed')
    }
  }
}
</script>
