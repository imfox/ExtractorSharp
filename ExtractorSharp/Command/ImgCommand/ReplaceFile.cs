﻿using ExtractorSharp.Core;
using ExtractorSharp.Data;
using ExtractorSharp.View;

namespace ExtractorSharp.Command.ImgCommand {
    /// <summary>
    /// 替换IMG文件
    /// </summary>
    class ReplaceFile : ICommand {
        private Album OldSource,Source,Target;
        public void Do(params object[] args) {
            Target=args[0] as Album;
            Source = args[1] as Album;
            if (Target == null || Source == null)
                return;
            OldSource = new Album();
            OldSource.Replace(Target);
            Target.Replace(Source);
            Messager.ShowOperate("ReplaceFile");
        }

        public void Undo() => Target.Replace(OldSource);
        

        public void Redo() => Do(Target, Source);        

        public void Batch(params object[] args) {
            var Album = args[0] as Album;
            if (Album == null || Source == null)
                return;
            Album.Replace(Source);
        }

        public bool CanUndo => true;

        public bool Changed => true;

        public string Name => "ReplaceFile";
        

    }
}