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
      <div class="modal-content bg-secondary text-primary p-2 input-round-1">
        <div class="d-flex justify-content-between">
          <h5 class="modal-title d-inline p-2 px-3" id="addAssignmentModalLabel">Add Keep</h5>
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
              <input class="input-round p-1" type="text" placeholder="Name" />
            </div>

            <label class="p-1 m-0">Description</label>

            <textarea
              class="input-round p-1 w-100"
              rows="4"
              type="text"
              placeholder="Description"
              required
            />

            <label class="p-1 m-0">Image url</label>

            <input
              class="input-round p-1 w-100 pr-5"
              type="text"
              placeholder="http://img/dogs/129dHypt34/.com"
            />

            <!-- <img class="p-1" v-if="true" src="https://placehold.it/150" alt /> -->

            <div class="d-flex justify-content-between align-items-center mt-3">
              <div class="mx-3 d-flex align-items-center">
                <label class="switch m-0">
                  <input type="checkbox" checked="true" />
                  <span class="slider round"></span>
                </label>
                <label v-if="isPublic" class="p-1 m-0">Public</label>
                <label v-else class="p-1 m-0">Private</label>
              </div>
              <div class="input-round-2">
                <button
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
      form: {},
      isPublic: true
    };
  },
  computed: {},
  methods: {}
};
</script>

<style>
</style>