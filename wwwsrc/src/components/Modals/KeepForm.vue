<template>
  <div
    class="modal fade"
    id="keepFormModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="addKeep"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content bg-secondary text-light p-2 input-round-1">
        <div class="d-flex justify-content-between">
          <h5 class="modal-title d-inline p-2 px-3">Add Keep</h5>
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
            <div class="d-flex justify-content-between">
              <div class>
                <label class="p-1 m-0">testing this still</label>
                <br />
                <input v-model="form.Name" class="input-round p-1" type="text" placeholder="Name" />
              </div>
              <a
                v-for="vault in vaults"
                :key="vault.id"
                class="btn btn-dark"
                type="button"
                @click="setVault(vault.name,vault.id)"
              >{{vault.name}}</a>
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

            <label class="p-1 m-0">Image url</label>

            <input
              v-model="form.Img"
              class="input-round p-1 w-100 pr-5"
              type="text"
              placeholder="http://img/dogs/129dHypt34/.com"
            />
            <div class="d-flex justify-content-between align-items-center mt-3">
              <div class="mx-3 d-flex align-items-center">
                <label class="switch m-0">
                  <input v-model="form.IsPrivate" type="checkbox" checked="true" />
                  <span class="slider round"></span>
                </label>
                <label v-if="form.IsPrivate" class="p-1 m-0">Private</label>
                <label v-else class="p-1 m-0">Public</label>
              </div>
              <div class="input-round-2">
                <button
                  v-if="this.targetVault.id"
                  @click="createKeep"
                  type="button"
                  data-dismiss="modal"
                  class="btn btn-success text-light input-round-1"
                >Create</button>
              </div>
            </div>
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
      },
      targetVault: {
        name: "",
        id: null
      }
    };
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.vaults;
    }
  },
  methods: {
    async createKeep() {
      let keep = await this.$store.dispatch("createKeepReturnId", this.form);
      this.form.KeepId = keep.id;
      this.form.VaultId = this.targetVault.id;
      debugger;
      this.$store.dispatch("addToVault", this.form);
    },
    setVault(name, id) {
      this.targetVault.name = name;
      this.targetVault.id = id;
    }
  }
};
</script>

<style>
</style>