const { ipcRenderer } = require('electron');

const fileList = document.getElementById('fileList');
let selectedFiles = [];

document.getElementById('chooseFiles').addEventListener('click', async () => {
  selectedFiles = await ipcRenderer.invoke('select-files');
  fileList.innerHTML = '';
  selectedFiles.forEach(file => {
    const li = document.createElement('li');
    li.textContent = file;
    fileList.appendChild(li);
  });
});

document.getElementById('saveArchive').addEventListener('click', async () => {
  if (selectedFiles.length === 0) {
    alert('Оберіть файли спочатку!');
    return;
  }
  const archivePath = await ipcRenderer.invoke('select-archive-destination');
  if (!archivePath) return;

  const result = await ipcRenderer.invoke('create-archive', selectedFiles, archivePath);
  document.getElementById('status').innerText = result;
});
