
const { app, BrowserWindow, dialog, ipcMain } = require('electron');
const path = require('path');
const fs = require('fs');
const archiver = require('archiver');

function createWindow() {
  const win = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      nodeIntegration: true,
      contextIsolation: false
    }
  });

  win.loadFile('index.html');
}

app.whenReady().then(() => {
  createWindow();
});

ipcMain.handle('select-files', async () => {
  const result = await dialog.showOpenDialog({
    properties: ['openFile', 'multiSelections']
  });
  return result.filePaths;
});

ipcMain.handle('select-archive-destination', async () => {
  const result = await dialog.showSaveDialog({
    filters: [{ name: 'Zip Files', extensions: ['zip'] }]
  });
  return result.filePath;
});

ipcMain.handle('create-archive', async (event, files, archivePath) => {
  return new Promise((resolve, reject) => {
    const output = fs.createWriteStream(archivePath);
    const archive = archiver('zip', { zlib: { level: 9 } });

    output.on('close', () => resolve(`Архів створено: ${archive.pointer()} байт`));
    archive.on('error', err => reject(err));

    archive.pipe(output);
    files.forEach(file => {
      archive.file(file, { name: path.basename(file) });
    });
    archive.finalize();
  });
});
