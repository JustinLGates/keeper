<template>
  <div
    class="modal fade"
    id="vaultFormModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="addKeep"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content bg-secondary text-primary p-2 input-round-1">
        <div class="d-flex justify-content-between">
          <h5 class="modal-title d-inline p-2 px-3" id="addAssignmentModalLabel">Add Vault</h5>
          <button
            type="button"
            class="p-2 px-3 close text-light"
            data-dismiss="modal"
            aria-label="Close"
          >
            <span class aria-hidden="true">
              <i class="text-light fas fa-times"></i>
            </span>
          </button>
        </div>
        <div class="modal-body m-0 p-0">
          <hr class="text-primary bg-primary m-0 p-0" />
          <form id="create-keep-form">
            <label class="p-1 m-0">Name</label>
            <div class="d-flex align-items-center">
              <input v-model="form.Name" class="input-round p-1" type="text" placeholder="Name" />
            </div>
            <label class="p-1 m-0">Description</label>
            <textarea
              v-model="form.Description"
              class="input-round p-1 w-100"
              rows="4"
              type="text"
              placeholder="Description"
              required
            />
            <button
              @click="createVault"
              type="button"
              data-dismiss="modal"
              class="btn btn-success text-light input-round-1"
            >Create</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        IsPrivate: false
      }
    };
  },
  computed: {},
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.form);
    }
  }
};
</script>

<style>
</style>