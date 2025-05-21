// App.jsx
import React, { useState } from 'react';
import JSZip from 'jszip';
import { saveAs } from 'file-saver';

export default function App() {
  const [files, setFiles] = useState([]);

  const handleFileChange = (e) => {
    setFiles(Array.from(e.target.files));
  };

  const createArchive = async () => {
    if (files.length === 0) {
      alert('Будь ласка, оберіть хоча б один файл.');
      return;
    }

    const zip = new JSZip();
    for (const file of files) {
      zip.file(file.name, file);
    }

    const content = await zip.generateAsync({ type: 'blob' });
    saveAs(content, 'archive.zip');
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-100 to-purple-200 flex items-center justify-center">
      <div className="bg-white shadow-lg rounded-2xl p-8 w-full max-w-md">
        <h1 className="text-3xl font-semibold text-gray-800 mb-6 text-center">Архіватор файлів</h1>

        <label className="block mb-4">
          <span className="text-gray-700">Оберіть файли</span>
          <input
            type="file"
            multiple
            onChange={handleFileChange}
            className="mt-2 w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-200"
          />
        </label>

        {files.length > 0 && (
          <ul className="mb-4 max-h-40 overflow-y-auto border p-2 rounded bg-gray-50">
            {files.map((file, idx) => (
              <li key={idx} className="text-sm text-gray-700 truncate">📄 {file.name}</li>
            ))}
          </ul>
        )}

        <button
          onClick={createArchive}
          className="w-full py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md transition"
        >
          📦 Створити ZIP
        </button>
      </div>
    </div>
  );
}
