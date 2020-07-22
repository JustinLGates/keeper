<template>
  <div
    class="modal fade"
    id="keepEditModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="editKeep"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
      <div class="modal-content bg-secondary text-primary p-2 input-round-1">
        <div class="d-flex justify-content-between">
          <h5 class="modal-title d-inline p-2 px-3">{{activeKeep.name}}</h5>
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

          <div class="p-1 row m-auto">
            <div class="p-0 col-12">
              <editKeep :keepData="activeKeep" class="w-100 shadow input-round-1" />
            </div>
            <div class="p-2 pt-2 col-12">
              <h5>{{this.$route.params.name}}</h5>
              <div></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import editKeep from "../KeepEdit";
export default {
  mounted() {
    this.form.IsPrivate = activeKeep.IsPrivate;
    this.form.id = activeKeep.id;
  },
  data() {
    return {
      form: {},
      targetVault: {
        name: "",
        id: null
      }
    };
  },
  computed: {
    activeKeep() {
      return this.$store.state.KeepsStore.activeKeep;
    },
    vaults() {
      return this.$store.state.VaultsStore.vaults;
    }
  },
  methods: {
    getKeep() {
      this.$store.dispatch("getKeep", this.form);
    },
    setVault(name, id) {
      this.targetVault.name = name;
      this.targetVault.id = id;
    },
    addToVault() {
      let data = {
        VaultId: this.targetVault.id,
        KeepId: this.activeKeep.id
      };
      this.$store.dispatch("addToVault", data);
    },
    removeKeep() {
      this.$store.dispatch("removeVaultKeep", this.activeKeep.id);
    }
  },

  components: {
    editKeep
  }
};
</script>

<style>
.h-80 {
  height: 80%;
}
.w-80 {
  width: 80%;
}
</style>