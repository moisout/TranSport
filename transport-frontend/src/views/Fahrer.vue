<template>
  <div class="fahrer">
    <v-data-table :headers="headers" :items="fahrer">
      <template v-slot:item.name="props">
        <v-edit-dialog
          :return-value.sync="props.item.name"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.name }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.name"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.nachname="props">
        <v-edit-dialog
          :return-value.sync="props.item.nachname"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.nachname }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.nachname"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.geburtsdatum="props">
        <v-edit-dialog
          :return-value.sync="props.item.geburtsdatum"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.geburtsdatum }}
          <template v-slot:input>
            <v-text-field v-model="props.item.geburtsdatum"></v-text-field>
            <v-date-picker v-model="props.item.geburtsdatum"></v-date-picker>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.telefonnummer="props">
        <v-edit-dialog
          :return-value.sync="props.item.telefonnummer"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.telefonnummer }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.telefonnummer"
              :rules="[max25chars]"
              label="Edit"
              single-line
              counter
            ></v-text-field>
          </template>
        </v-edit-dialog>
      </template>
      <template v-slot:item.email="props">
        <v-edit-dialog
          :return-value.sync="props.item.email"
          @save="save"
          @cancel="cancel"
          @open="open"
          @close="close"
        >
          {{ props.item.email }}
          <template v-slot:input>
            <v-text-field
              v-model="props.item.email"
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
  name: 'fahrer',
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
        text: 'Name',
        align: 'left',
        sortable: false,
        value: 'name'
      },
      { text: 'Nachname', value: 'nachname' },
      { text: 'Geburtsdatum', value: 'geburtsdatum' },
      { text: 'Telefonnummer', value: 'telefonnummer' },
      { text: 'Email', value: 'email' }
    ],
    fahrer: DataStore.fahrer
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
