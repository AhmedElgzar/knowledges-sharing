# -*- coding: utf-8 -*-
import datetime
from south.db import db
from south.v2 import SchemaMigration
from django.db import models


class Migration(SchemaMigration):

    def forwards(self, orm):

        # Changing field 'Track.url'
        db.alter_column(u'main_track', 'url', self.gf('django.db.models.fields.files.FileField')(max_length=100))

    def backwards(self, orm):

        # Changing field 'Track.url'
        db.alter_column(u'main_track', 'url', self.gf('django.db.models.fields.TextField')())

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
            'url': ('django.db.models.fields.files.FileField', [], {'max_length': '100'})
        }
    }

    complete_apps = ['main']