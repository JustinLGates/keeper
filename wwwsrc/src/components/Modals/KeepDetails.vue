<template>
  <div
    class="modal fade"
    id="keepDetailsModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="addKeep"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
      <div class="modal-content bg-secondary text-primary p-2 input-round-1">
        <div class="d-flex justify-content-between">
          <h5 class="modal-title d-inline p-2 px-3" id="addAssignmentModalLabel">{{activeKeep.name}}</h5>
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

          <div class="p-2 row m-auto">
            <div class="p-2 col-6 col-sm-8 col-lg-9 w-80">
              <keep :keepData="activeKeep" class="w-80 shadow input-round-1" />
            </div>
            <div class="pt-2 col-6 col-sm-4 col-lg-3 d-flex flex-column justify-content-between">
              <div class="dropdown">
                <span
                  type="button"
                  id="dropdownMenuOffset"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  data-offset="-30,10"
                >
                  Vaults
                  <i class="fas fa-chevron-down"></i>
                </span>
                <div class="dropdown-menu bg-secondary" aria-labelledby="dropdownMenuOffset">
                  <a
                    v-for="vault in vaults"
                    :key="vault.id"
                    class="dropdown-item text-primary"
                    type="button"
                    @click="setVault(vault.name,vault.id)"
                  >{{vault.name}}</a>
                </div>
              </div>
              <div>
                <br />
                <button
                  v-if="this.targetVault.id"
                  @click="addToVault"
                  class="btn btn-info text-light"
                >Add to {{this.targetVault.name}}</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../Keep";
export default {
  data() {
    return {
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
    }
  },

  components: {
    keep
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