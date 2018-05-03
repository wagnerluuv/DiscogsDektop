﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlSelector;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class VideoControlModel : DependencyObject
    {
        public VideoModel VideoModel { get; }

        public string VideoFilePath { get; private set; }

        public bool DownloadSuccessfull { get; private set; }

        public event Action LoadingFinished;

        public VideoControlModel(VideoModel videoModel)
        {
            this.VideoModel = videoModel;
        }

        public void StartLoading()
        {
            Task.Run(() =>
            {
                Task.WaitAll();

                this.DownloadSuccessfull = MediaService.GetVideoFilePath(this.VideoModel.Url, out string path);
                this.VideoFilePath = path;

                this.LoadingFinished?.Invoke();
            });
        }

        public void PlayAudio()
        {
            GlobalControls.SoundPlayerControl.Play(this.VideoFilePath, this.VideoModel.Title);
        }

        public void PlayVideo()
        {
            Process.Start(this.VideoFilePath);
        }

        public void OpenVideoUrl()
        {
            Process.Start(this.VideoModel.Url);
        }
    }
}