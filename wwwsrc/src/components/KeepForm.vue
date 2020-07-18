<template>
  <div
    class="modal fade"
    id="keepFormModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="addKeep"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-lg modal-dialog-center" role="document">
      <div class="modal-content bg-secondary text-primary">
        <div class="modal-header">
          <h5 class="modal-title" id="addAssignmentModalLabel">Add Keep</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span class aria-hidden="true">
              <i class="text-primary fas fa-times"></i>
            </span>
          </button>
        </div>
        <div class="modal-body">
          <form id="create-keep-form">
            <input class="input-round p-2" type="text" placeholder="Name / Title" />
            <input class="input-round p-2" type="text" placeholder="Description" required />
            <input class="input-round p-2" type="text" placeholder="img url" />
            <label class="switch">
              <input type="checkbox" />
              <span class="slider round"></span>
            </label>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" data-dismiss="modal" class="btn btn-success">Create</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {}
    };
  },
  computed: {},
  methods: {}
};
</script>

<style>
</style>