# -*- coding: utf-8 -*-
import datetime
from south.db import db
from south.v2 import SchemaMigration
from django.db import models


class Migration(SchemaMigration):

    def forwards(self, orm):
        # Adding model 'Track'
        db.create_table(u'main_track', (
            (u'id', self.gf('django.db.models.fields.AutoField')(primary_key=True)),
            ('name', self.gf('django.db.models.fields.CharField')(max_length=256)),
            ('artist', self.gf('django.db.models.fields.CharField')(max_length=256)),
            ('url', self.gf('django.db.models.fields.TextField')()),
            ('rate', self.gf('django.db.models.fields.IntegerField')()),
        ))
        db.send_create_signal(u'main', ['Track'])

        # Adding model 'Playlist'
        db.create_table(u'main_playlist', (
            (u'id', self.gf('django.db.models.fields.AutoField')(primary_key=True)),
            ('name', self.gf('django.db.models.fields.CharField')(max_length=256)),
        ))
        db.send_create_signal(u'main', ['Playlist'])

        # Adding M2M table for field tracks on 'Playlist'
        m2m_table_name = db.shorten_name(u'main_playlist_tracks')
        db.create_table(m2m_table_name, (
            ('id', models.AutoField(verbose_name='ID', primary_key=True, auto_created=True)),
            ('playlist', models.ForeignKey(orm[u'main.playlist'], null=False)),
            ('track', models.ForeignKey(orm[u'main.track'], null=False))
        ))
        db.create_unique(m2m_table_name, ['playlist_id', 'track_id'])


    def backwards(self, orm):
        # Deleting model 'Track'
        db.delete_table(u'main_track')

        # Deleting model 'Playlist'
        db.delete_table(u'main_playlist')

        # Removing M2M table for field tracks on 'Playlist'
        db.delete_table(db.shorten_name(u'main_playlist_tracks'))


    models = {
        u'main.playlist': {
            'Meta': {'object_name': 'Playlist'},
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            'tracks': ('django.db.models.fields.related.ManyToManyField', [], {'to': u"orm['main.Track']", 'symmetrical': 'False'})
        },
        u'main.track': {
            'Meta': {'object_name': 'Track'},
            'artist': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            'rate': ('django.db.models.fields.IntegerField', [], {}),
            'url': ('django.db.models.fields.TextField', [], {})
        }
    }

    complete_apps = ['main']