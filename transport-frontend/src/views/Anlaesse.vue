<template>
  <div class="anlaesse">
    <v-data-table :headers="headers" :items="anlaesse">
      <template v-slot:item.titel="props">
        <v-edit-dialog
          :return-value.sync="props.item.titel"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.titel }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.titel"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.datum="props">
        <v-edit-dialog
          :return-value.sync="props.item.datum"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.datum }}
          <template v-slot:input>
            <v-text-field v-model="props.item.datum"></v-text-field>
            <v-date-picker v-model="props.item.datum"></v-date-picker>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.zeit="props">
        <v-edit-dialog
          :return-value.sync="props.item.zeit"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.zeit }}
          <template v-slot:input>
            <v-text-field v-model="props.item.zeit"></v-text-field>
            <v-time-picker v-model="props.item.zeit"></v-time-picker>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.teilnehmer="props">
        <v-edit-dialog
          :return-value.sync="props.item.teilnehmer"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.teilnehmer }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.teilnehmer"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.adresse="props">
        <v-edit-dialog
          :return-value.sync="props.item.adresse"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.adresse }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.adresse"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.ort="props">
        <v-edit-dialog
          :return-value.sync="props.item.ort"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.ort }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.ort"
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
  name: 'anlaesse',
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
        text: 'Titel',
        align: 'left',
        sortable: false,
        value: 'titel'
      },
      { text: 'Datum', value: 'datum' },
      { text: 'Zeit', value: 'zeit' },
      { text: 'Teilnehmer', value: 'teilnehmer' },
      { text: 'Adresse', value: 'adresse' },
      { text: 'Ort', value: 'ort' }
    ],
    anlaesse: DataStore.anlaesse
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
